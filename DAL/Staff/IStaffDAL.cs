using Persistence;


namespace DAL
{
    public interface IStaffDAL
    {
        public Staff Login(string userName, string password);
    }
}