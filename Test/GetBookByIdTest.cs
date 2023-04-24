using DAL;
using Persistence;

namespace Test
{
    public class GetBookByIdTest
    {
        BookDAL bookDal = new BookDAL();

        [Fact]
        public void GetBookByIdTest1()
        {
            int keySearch = 1;
            Book result = bookDal.GetBookById(keySearch);
            Assert.True(result != null);
        }

        [Fact]
        public void GetBookByIdTest2()
        {
            int keySearch = 2;
            Book result = bookDal.GetBookById(keySearch);
            Assert.True(result != null);
        }

        [Fact]
        public void GetBookByIdTest3()
        {
            int keySearch = 3;
            Book result = bookDal.GetBookById(keySearch);
            Assert.True(result != null);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2.5)]
        public void GetBookByIdTest4(int keySearch)
        {
            Book result = bookDal.GetBookById(keySearch);
            Assert.True(result == null);
        }
    }
}