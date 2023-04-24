using MySql.Data.MySqlClient;
using Persistence;
using System.Text.RegularExpressions;

namespace DAL
{
    public class OrderDAL : IOrderDAL
    {
        private MySqlDataReader? reader;
        private MySqlConnection connection = DbConfig.GetConnection();

        public List<Order> GetOrderById(int keySearch)
        {
            List<Order> list = new List<Order>();
            MySqlCommand cmd = new MySqlCommand("sp_getOrderById", connection);
            try
            {
                connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderId", keySearch);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order = GetOrder(reader);
                        list.Add(order);
                    }
                    reader.Close();
                }
            }
            catch
            {
                Console.WriteLine("Disconnected database");
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public bool CreateOrder(Order order)
        {
            if (order == null || order.booksList == null || order.booksList.Count == 0)
            {
                return false;
            }
            bool result = false;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                //Khoá cập nhật tất cả table, bảo đảm tính toàn vẹn dữ liệu
                cmd.CommandText = "lock tables staffs write, books write, categorys write, customers write, order_details write, orders write;";
                cmd.ExecuteNonQuery();
                MySqlTransaction trans = connection.BeginTransaction();
                cmd.Transaction = trans;
                bool check = false;
                if (order.orderCustomer == null || order.orderCustomer.customerName == null || order.orderCustomer.customerName == "")
                {
                    order.orderCustomer = new Customer() { customerId = 1 };
                }
                try
                {
                    Console.Write("Enter customer phone number: ");
                    string customerPhone = Console.ReadLine() ?? "";
                    while (true)
                    {
                        if (Regex.Match(customerPhone, @"^(0|84)(2(0[3-9]|1[0-6|8|9]|2[0-2|5-9]|3[2-9]|4[0-9]|5[1|2|4-9]|6[0-3|9]|7[0-7]|8[0-9]|9[0-4|6|7|9])|3[2-9]|5[5|6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])([0-9]{7})$").Success)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid phone number!");
                            Console.Write("Enter customer phone number: ");
                            customerPhone = Console.ReadLine() ?? "";
                        }
                    }
                    cmd.CommandText = $"select * from customers where customer_phone = {customerPhone};";
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Console.WriteLine($"Old customer: {reader.GetString("customer_name")}");
                        order.orderCustomer.customerPhone = reader.GetString("customer_phone");
                        order.orderCustomer.customerId = reader.GetInt32("customer_id");
                        order.orderCustomer.customerName = reader.GetString("customer_name");
                        check = true;
                    }
                    reader.Close();
                    if (!check)
                    {
                        Console.Write("Enter customer name: ");
                        string customerName = Console.ReadLine() ?? "";
                        order.orderCustomer = new Customer { customerName = customerName, customerPhone = customerPhone };
                        cmd.CommandText = $"insert into customers(customer_name, customer_phone) values ('{order.orderCustomer.customerName}', '{order.orderCustomer.customerPhone}');";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "select last_insert_id() as customer_id;";
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            order.orderCustomer.customerId = reader.GetInt32("customer_id");
                        }
                        reader.Close();
                    }
                    cmd.CommandText = $"insert into orders(customer_id, staff_id, order_status) values ({order.orderCustomer!.customerId}, {order.orderStaff!.staffId}, {OrderStatus.UNPAID});";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select last_insert_id() as order_id;";
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        order.orderId = reader.GetInt32("order_id");
                    }
                    reader.Close();
                    cmd.CommandText = "select order_date from orders order by order_id desc limit 1;";
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        order.orderDate = reader.GetDateTime("order_date");
                    }
                    reader.Close();
                    foreach (Book book in order.booksList)
                    {
                        cmd.CommandText = $"select book_price from books where book_id={book.bookId};";
                        reader = cmd.ExecuteReader();
                        if (!reader.Read())
                        {
                            throw new Exception("Does not exist");
                        }
                        book.bookPrice = reader.GetDecimal("book_price");
                        reader.Close();
                        cmd.CommandText = $"insert into order_details(order_id, book_id, unit_price, quantity) values ({order.orderId}, {book.bookId}, {book.bookPrice * book.bookQuantity}, {book.bookQuantity});";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"update books set book_quantity=book_quantity-{book.bookQuantity} where book_id={book.bookId};";
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    result = true;
                }
                catch
                {
                    Console.WriteLine("Disconnected database");
                    try
                    {
                        trans.Rollback();
                    }
                    catch
                    {
                        Console.WriteLine("Disconnected database");
                    }
                }
                finally
                {
                    cmd.CommandText = "unlock tables;";
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                Console.WriteLine("Disconnected database");
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public List<Order> GetAllPaidOrdersInDay()
        {
            List<Order> list = new List<Order>();
            Order order = null!;
            MySqlCommand cmd = new MySqlCommand("sp_getPaidOrdersInDay", connection);
            try
            {
                connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        order = new Order();
                        order = GetOrder(reader);
                        list.Add(order);
                    }
                    if (list == null || list.Count == 0)
                    {
                        reader.Close();
                        return null!;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Disconnected database");
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public List<Order> GetAllUnpaidOrdersInDay()
        {
            List<Order> list = new List<Order>();
            Order order = null!;
            MySqlCommand cmd = new MySqlCommand("sp_getUnpaidOrdersInDay", connection);
            try
            {
                connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        order = new Order();
                        order = GetOrder(reader);
                        list.Add(order);
                    }
                    if (list == null || list.Count == 0)
                    {
                        reader.Close();
                        return null!;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Disconnected database");
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public bool CancelPayment(List<Order> ordersList, bool check)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                if (check == false)
                {
                    foreach (Order item in ordersList)
                    {
                        cmd.CommandText = $"update books set book_quantity=book_quantity+{item.orderBook!.bookQuantity} where book_id={item.orderBook.bookId};";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Disconnected database");
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool ChangeStatus(int orderId, bool check)
        {
            bool result = false;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                if (check == true)
                {
                    cmd.CommandText = $"update orders set order_status = {OrderStatus.PAID} where order_id = {orderId};";
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                else
                {
                    cmd.CommandText = $"update orders set order_status = {OrderStatus.CANCEL} where order_id = {orderId};";
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                Console.WriteLine("Disconnected database");
            }
            finally
            {
                connection.Close();
            }
            return result;
        }


        private Order GetOrder(MySqlDataReader reader)
        {
            Order order = new Order();
            order.orderStaff!.staffName = reader.GetString("staff_name");
            order.orderCustomer!.customerName = reader.GetString("customer_name");
            order.orderCustomer.customerPhone = reader.GetString("customer_phone");
            order.orderId = reader.GetInt32("order_id");
            order.orderDate = reader.GetDateTime("order_date");
            order.orderStatus = reader.GetInt32("order_status");
            order.orderBook!.bookId = reader.GetInt32("book_id");
            order.orderBook.bookName = reader.GetString("book_name");
            order.orderBook.bookPrice = reader.GetDecimal("book_price");
            order.orderBook.bookQuantity = reader.GetInt32("quantity");
            order.orderBook.bookAmount = reader.GetDecimal("unit_price");
            order.booksList!.Add(order.orderBook);
            return order;
        }
    }
}