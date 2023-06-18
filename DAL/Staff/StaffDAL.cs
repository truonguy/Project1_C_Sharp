using MySql.Data.MySqlClient;
using Persistence;


namespace DAL
{
    public class StaffDAL : IStaffDAL
    {
        private MySqlConnection connection = DbConfig.GetConnection();

        // Phương thức để đăng nhập vào hệ thống với tên đăng nhập và mật khẩu được cung cấp
        // Tham số truyền vào: một chuỗi tên đăng nhập và một chuỗi mật khẩu
        // Trả về giá trị: đối tượng Staff nếu tên đăng nhập và mật khẩu chính xác, ngược lại trả về null
        public Staff Login(string userName, string password)
        {
            Staff staff = null!; // Khởi tạo đối tượng Staff là null

            // Khởi tạo một đối tượng MySqlCommand để thực thi truy vấn đăng nhập trong cơ sở dữ liệu
            MySqlCommand cmd = new MySqlCommand("sp_login", connection);

            try
            {
                // System.Console.WriteLine(Md5Algorithms.CreateMD5(password));
                connection.Open(); // Mở kết nối đến cơ sở dữ liệu

                // Thiết lập loại câu lệnh của MySqlCommand là Stored Procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Thêm các tham số vào MySqlCommand, bao gồm tên đăng nhập và mật khẩu được mã hóa MD5
                cmd.Parameters.AddWithValue("@username", userName);
                cmd.Parameters.AddWithValue("@password", Md5Algorithms.CreateMD5(password));

                // Thực thi truy vấn đăng nhập và lấy ra kết quả trả về trong đối tượng MySqlDataReader
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Nếu đọc được một bản ghi trong kết quả trả về, tức là tên đăng nhập và mật khẩu chính xác
                    if (reader.Read())
                    {
                        // Gán đối tượng Staff bằng đối tượng Staff được trả về bởi phương thức GetStaff
                        staff = GetStaff(reader);
                    }

                    reader.Close(); // Đóng MySqlDataReader
                }
            }
            catch
            {
                Console.WriteLine("Disconnected database"); // In ra thông báo nếu có lỗi khi kết nối đến cơ sở dữ liệu
            }
            finally
            {
                connection.Close(); // Đóng kết nối đến cơ sở dữ liệu
            }

            // Trả về đối tượng Staff, nếu tên đăng nhập và mật khẩu chính xác, ngược lại trả về null
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