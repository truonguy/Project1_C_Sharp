using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class BookDAL : IBookDAL
    {
        private MySqlConnection connection = DbConfig.GetConnection();

        public Book GetBookById(int keySearch)
        {
            Book book = null!;
            MySqlCommand cmd = new MySqlCommand("sp_getBookById", connection);
            try
            {
                connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookId", keySearch);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        book = GetBook(reader);
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
            return book;
        }

        public List<Book> GetBookByBookName(string keySearch)
        {
            List<Book> list = new List<Book>();
            MySqlCommand cmd = new MySqlCommand("sp_getBookByBookName", connection);
            try
            {
                connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookName", keySearch);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = GetBook(reader);
                        list.Add(book);
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

        public List<Book> GetBookByCategoryName(string keySearch)
        {
            List<Book> list = new List<Book>();
            MySqlCommand cmd = new MySqlCommand("sp_getBookByCategoryName", connection);
            try
            {
                connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoryName", keySearch);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = GetBook(reader);
                        list.Add(book);
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

        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            MySqlCommand cmd = new MySqlCommand("sp_getAllBook", connection);
            try
            {
                connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = GetBook(reader);
                        list.Add(book);
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


        private Book GetBook(MySqlDataReader reader)
        {
            Book book = new Book();
            book.bookId = reader.GetInt32("book_id");
            book.bookName = reader.GetString("book_name");
            book.authorName = reader.GetString("author_name");
            book.bookPrice = reader.GetDecimal("book_price");
            book.bookDescription = reader.GetString("book_description");
            book.bookQuantity = reader.GetInt32("book_quantity");
            book.bookCategory!.categoryName = reader.GetString("category_name");
            return book;
        }
    }
}