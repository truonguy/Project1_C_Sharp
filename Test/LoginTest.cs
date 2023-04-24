using DAL;
using Persistence;

namespace Test
{
    public class LoginTest
    {
        private StaffDAL staffDal = new StaffDAL();

        [Fact]
        public void LoginTest1()
        {
            string userName = "seller123";
            string password = "seller123";
            Staff result = staffDal.Login(userName, password);
            Assert.True(result != null);
            Assert.True(result!.staffRole == 1);
        }

        [Fact]
        public void LoginTest2()
        {
            string userName = "accountant123";
            string password = "accountant123";
            Staff result = staffDal.Login(userName, password);
            Assert.True(result != null);
            Assert.True(result!.staffRole == 2);
        }

        [Theory]
        [InlineData("staff001", "pf1304")]
        [InlineData("staff002", "pf1304VTCA")]
        [InlineData("asdfg", "asdfg")]
        public void LoginTest4(string userName, string password)
        {
            Staff result = staffDal.Login(userName, password);
            Assert.True(result == null);
        }
    }
}