using MySql.Data.MySqlClient;
using Persistence;


namespace DAL
{
    public class StaffDAL : IStaffDAL
    {
        private MySqlConnection connection = DbConfig.GetConnection();

        public Staff Login(string userName, string password)
        {
            Staff staff = null!;
            MySqlCommand cmd = new MySqlCommand("sp_login", connection);
            try
            {
                // System.Console.WriteLine(Md5Algorithms.CreateMD5(password));
                connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", userName);
                cmd.Parameters.AddWithValue("@password", Md5Algorithms.CreateMD5(password));
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        staff = GetStaff(reader);
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
            return staff;
        }

        private Staff GetStaff(MySqlDataReader reader)
        {
            Staff staff = new Staff();
            staff.staffId = reader.GetInt32("staff_id");
            staff.staffName = reader.GetString("staff_name");
            staff.staffRole = reader.GetInt32("staff_role");
            return staff;
        }
    }
}