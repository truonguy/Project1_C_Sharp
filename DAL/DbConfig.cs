using MySql.Data.MySqlClient;


namespace DAL
{
    public class DbConfig
    {
        private static MySqlConnection? connection;
        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection
                {
                    ConnectionString = "server=localhost;userid=root;password=123456;port=3306;database=bookstore;"
                };
            }
            return connection;
        }
    }
}