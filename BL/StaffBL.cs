using Persistence;
using DAL;


namespace BL
{
    public class StaffBL
    {
        private StaffDAL staffDal = new StaffDAL();

        public Staff Login(string userName, string password)
        {
            return staffDal.Login(userName, password);
        }
    }
}