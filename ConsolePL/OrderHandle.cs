using Persistence;
using BL;
using Utilities;
using System.Text.RegularExpressions;

namespace ConsolePL
{
    public class OrderHandle
    {
        static OrderBL orderBl = new OrderBL();
        static BookBL bookBl = new BookBL();

        public static void ShowTransactionHistory()
        {
            Console.Clear();
            List<Order> ordersList = new List<Order>();
            ordersList = orderBl.GetAllPaidOrdersInDay();
            if (ordersList == null || ordersList.Count == 0)
            {
                Utility.WaitForKey("No orders have been created today! Enter any key to go back...");
                return;
            }
            Console.WriteLine("===========================================================================================================================");
            Console.WriteLine("|                                                   Transaction history                                                   |");
            Console.WriteLine("===========================================================================================================================");
            Console.WriteLine("| Order id     Creator               Customer               Creation time             Total amount           Status       |");
            Console.WriteLine("| ----------   --------------        --------------         -------------             -------------          ------------ |");
            foreach (Order order in ordersList)
            {
                Console.WriteLine($"| {order.orderId,-12} {order.orderStaff!.staffName,-21} {order.orderCustomer!.customerName,-22} {order.orderDate,-25} {Utility.FormatCurrency(order.orderBook!.bookAmount.ToString()),-22} {"PAID",-12} |");
            }
            Console.WriteLine("===========================================================================================================================");
            Utility.WaitForKey("Enter any key to continue...");
        }

        public static void CreateOrder(Staff staff)
        {
            List<Book> list = new List<Book>();
            Order order = new Order();
            list = bookBl.GetAllBooks();
            order.orderStaff = staff;
            if (list.Count == 0)
            {
                Console.WriteLine("No books!");
                Utility.WaitForKey("Enter any key to continue...");
                return;
            }
            else
            {
                int size = 10;
                int page = 1;
                int pages = (int)Math.Ceiling((double)list.Count / size);
                int k = 0;
                string choose, price;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine("|                                                          All books                                                           |");
                    Console.WriteLine($"|                                                                                                                     Page {page}/{pages} |");
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine("| Book id   | Book title                                                            | Price           | Type                   |");
                    if (list.Count < size)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            price = Utility.FormatCurrency(list[i].bookPrice.ToString());
                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine($"| {list[i].bookId,-9} | {list[i].bookName,-69} | {price,-15} | {list[i].bookCategory!.categoryName,-22} |");
                        }
                    }
                    else
                    {
                        for (int i = ((page - 1)) * size; i < k + 10; i++)
                        {
                            if (i == list.Count)
                            {
                                break;
                            }
                            price = Utility.FormatCurrency(list[i].bookPrice.ToString());
                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine($"| {list[i].bookId,-9} | {list[i].bookName,-69} | {price,-15} | {list[i].bookCategory!.categoryName,-22} |");
                        }
                    }
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine("Enter P to view the previous page.");
                    Console.WriteLine("Enter N to view the next page.");
                    Console.WriteLine("Enter book id to add to order.");
                    Console.WriteLine("Enter 0 to go back.");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.Write("Choose: ");
                    choose = Console.ReadLine() ?? "";
                    while (true)
                    {
                        if (Regex.Match(choose, @"([PpNn]|[1-9]|^0$)").Success)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("Invalid selection! re-select: ");
                            choose = Console.ReadLine() ?? "";
                        }
                    }
                    choose = choose.Trim();
                    choose = choose.ToLower();
                    string number = Regex.Match(choose, @"\d+").Value;
                    if (choose == "n")
                    {
                        if (page == pages)
                        {
                            Utility.WaitForKey("No next page! Enter any key to continue...");
                        }
                        else
                        {
                            page = page + 1;
                            k = k + 10;
                        }
                    }
                    else if (choose == "p")
                    {
                        if (page == 1)
                        {
                            Utility.WaitForKey("No previous page! Enter any key to continue...");
                        }
                        else
                        {
                            page = page - 1;
                            k = k - 10;
                        }
                    }
                    else if (choose == "0")
                    {
                        return;
                    }
                    else
                    {
                        bool found = false;
                        string search = '"' + choose + '"';
                        for (int i = ((page - 1)) * size; i < k + 10; i++)
                        {
                            try
                            {
                                if (int.Parse(choose) == list[i].bookId)
                                {
                                    BookHandle.ShowBookDetail(list[i], search);
                                    Book book = bookBl.GetBookById(list[i].bookId);
                                    found = true;
                                    if (book.bookId <= 0)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        string strQuantity;
                                        bool isSuccess;
                                        int quantity;
                                        while (true)
                                        {
                                            Console.Write("Enter the number of books to buy: ");
                                            strQuantity = Console.ReadLine() ?? "";
                                            isSuccess = int.TryParse(strQuantity, out quantity);
                                            while (!isSuccess)
                                            {
                                                Console.Write("Invalid quantity! Enter the number of books to buy: ");
                                                strQuantity = Console.ReadLine() ?? "";
                                                isSuccess = int.TryParse(strQuantity, out quantity);
                                            }
                                            if (book.bookQuantity <= 0)
                                            {
                                                Console.WriteLine("This book is out of stock!");
                                                continue;
                                            }
                                            else if (quantity <= 0)
                                            {
                                                Console.WriteLine("Invalid input quantity!");
                                                continue;
                                            }
                                            else if (quantity > book.bookQuantity)
                                            {
                                                Console.WriteLine("The number of purchases exceeds the number of books available!");
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        decimal amount = (decimal)quantity * book.bookPrice;
                                        book.bookQuantity = quantity;
                                        book.bookAmount = amount;
                                        bool add = true;
                                        if (order.booksList == null || order.booksList.Count == 0)
                                        {
                                            order.booksList!.Add(book);
                                        }
                                        else
                                        {
                                            for (i = 0; i < order.booksList.Count; i++)
                                            {
                                                if (int.Parse(choose) == order.booksList[i].bookId)
                                                {
                                                    order.booksList[i].bookQuantity += quantity;
                                                    order.booksList[i].bookAmount += amount;
                                                    add = false;
                                                }
                                            }
                                            if (add)
                                            {
                                                order.booksList.Add(book);
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            catch (System.FormatException) { }
                            catch (System.ArgumentOutOfRangeException) { }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Invalid book id!");
                            Utility.WaitForKey("Enter any key to continue...");
                        }
                        if (!Utility.IsContinue("Do you want to add another book to your order? (Y/N): "))
                        {
                            break;
                        }
                    }
                }
            }
            if (orderBl.CreateOrder(order))
            {
                Console.WriteLine("Successful order creation!");
            }
            else
            {
                Console.WriteLine("The order has no books!");
                Console.WriteLine("Order creation failed!");
            }
            Utility.WaitForKey("Enter any key to continue...");
        }

        public static void ShowListOfUnpaidOrders()
        {
            Console.Clear();
            int choice;
            List<Order> ordersList = new List<Order>();
            ordersList = orderBl.GetAllUnpaidOrdersInDay();
            if (ordersList == null || ordersList.Count == 0)
            {
                Utility.WaitForKey("No orders have been created today! Enter any key to go back...");
                return;
            }
            Console.WriteLine("===========================================================================================================================");
            Console.WriteLine("|                                                      List of orders                                                      |");
            Console.WriteLine("===========================================================================================================================");
            Console.WriteLine("| Order id         Customer            Customer phone       Creation time             Total amount           Status       |");
            Console.WriteLine("| ----------       --------------      ---------------      --------------            ------------           ------------ |");
            foreach (Order item in ordersList)
            {
                Console.WriteLine($"| {item.orderId,-16} {item.orderCustomer!.customerName,-19} {item.orderCustomer.customerPhone,-20} {item.orderDate,-25} {Utility.FormatCurrency(item.orderBook!.bookAmount.ToString()),-22} {"UNPAID",-12} |");
            }
            Console.WriteLine("===========================================================================================================================");
            while (true)
            {
                Console.Write("Enter order id to pay (enter 0 to exit): ");
                int.TryParse(Console.ReadLine(), out choice);
                bool found = false;
                foreach (Order item in ordersList)
                {
                    if (choice == item.orderId)
                    {
                        found = true;
                        break;
                    }
                    else if (choice == 0)
                    {
                        return;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Invalid order id, please re-enter");
                }
                else
                {
                    break;
                }
            }
            foreach (Order item in ordersList)
            {
                if (choice == item.orderId)
                {
                    ordersList = orderBl.GetOrderById(choice);
                    foreach (Order order in ordersList)
                    {
                        ShowOrderDetailsToPayment(ordersList, order);
                        break;
                    }
                    break;
                }
            }
        }

        public static void ShowOrderDetailsToPayment(List<Order> ordersList, Order order)
        {
            Console.Clear();
            Console.WriteLine("=================================================================================================");
            Console.WriteLine("|                                            Invoice                                            |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Time: {order.orderDate,-61}          order id: {order.orderId,6} |");
            Console.WriteLine($"| sales agent: {order.orderStaff!.staffName,-41}                     Address: TP.Hà Nội |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Items                                                      Unit price    Quantity      Amount |");
            foreach (Order item in ordersList)
            {
                Console.WriteLine($"| {item.orderBook!.bookName,-59} {Utility.FormatCurrency(item.orderBook!.bookPrice.ToString()),9} {item.orderBook!.bookQuantity,11} {Utility.FormatCurrency(item.orderBook!.bookAmount.ToString()),11} |");
                order.total += item.orderBook!.bookAmount;
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            string total = Utility.FormatCurrency(order.total.ToString());
            Console.WriteLine($"| THE TOTAL AMOUNT PAYABLE  {total,63} VND |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Customer name: {order.orderCustomer!.customerName,-49} Customer phone: {order.orderCustomer!.customerPhone,12} |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Payment(ordersList, order);
        }

        public static void Payment(List<Order> ordersList, Order order)
        {
            Payment payment = new Payment();
            string paymentAmount;
            string refund;
            bool check;
            Console.Write("Do you want to pay?(Y: Yes | N: Cancel | 0: Back): ");
            string input = Console.ReadLine() ?? "";
            while (true)
            {
                if (Regex.Match(input, @"^[yYnN0]$").Success)
                {
                    break;
                }
                else
                {
                    Console.Write("Choose (Y/N/0): ");
                    input = Console.ReadLine() ?? "";
                }
            }
            if (input == "y" || input == "Y")
            {
                check = true;
            }
            else if (input == "n" || input == "N")
            {
                check = false;
            }
            else
            {
                return;
            }

            if (check == true)
            {
                while (true)
                {
                    Console.Write("Enter the amount to be paid by the customer: ");
                    paymentAmount = Console.ReadLine() ?? "";
                    while (true)
                    {
                        if (Regex.Match(paymentAmount, @"((?<=\s)|^)[-+]?((\d{1,3}([,\s.']\d{3})*)|\d+)([.,/-]\d+)?((?=\s)|$)").Success)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount!");
                            Console.Write("Enter the amount to be paid by the customer: ");
                            paymentAmount = Console.ReadLine() ?? "";
                        }
                    }
                    if (Convert.ToDecimal(paymentAmount) >= order.total && Convert.ToDecimal(paymentAmount) % 1000 == 0)
                    {
                        payment.paymentAmount = Convert.ToDecimal(paymentAmount);
                        paymentAmount = Utility.FormatCurrency(payment.paymentAmount.ToString());

                        payment.refund = payment.paymentAmount - order.total;
                        refund = Utility.FormatCurrency(payment.refund.ToString());
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The amount you entered is incorrect! Please re-enter!");
                    }
                }
                if (orderBl.ChangeStatus(order.orderId, check))
                {
                    ShowInvoice(ordersList, order, paymentAmount, refund);
                }
            }
            else
            {
                orderBl.ChangeStatus(order.orderId, check);
                if (orderBl.CancelPayment(ordersList, check))
                {
                    Console.WriteLine("order cancel successfully!");
                }
                Utility.WaitForKey("Enter any key to continue...");
            }
        }


        public static void ShowInvoice(List<Order> ordersList, Order order, string paymentAmount, string refund)
        {
            Console.Clear();
            Console.WriteLine("=================================================================================================");
            Console.WriteLine("|                                            Invoice                                            |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Time: {order.orderDate,-61}          order id: {order.orderId,6} |");
            Console.WriteLine($"| sales agent: {order.orderStaff!.staffName,-41}                     Address: TP.Hà Nội |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Items                                                      Unit price    Quantity      Amount |");
            foreach (Order item in ordersList)
            {
                Console.WriteLine($"| {item.orderBook!.bookName,-59} {Utility.FormatCurrency(item.orderBook!.bookPrice.ToString()),9} {item.orderBook!.bookQuantity,11} {Utility.FormatCurrency(item.orderBook!.bookAmount.ToString()),11} |");
            }
            string total = Utility.FormatCurrency(order.total.ToString());
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|                                                        + Total amount: {total,18} VND |");
            Console.WriteLine($"|                                                        + Payments    : {paymentAmount,18} VND |");
            Console.WriteLine($"|                                                        + Refund      : {refund,18} VND |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                    THANK YOU AND SEE ALSO!                                    |");
            Console.WriteLine("|                                  Website: www.bookstore.com                                   |");
            Console.WriteLine("=================================================================================================");
            Utility.WaitForKey("Enter any key to continue...");
        }
    }
}