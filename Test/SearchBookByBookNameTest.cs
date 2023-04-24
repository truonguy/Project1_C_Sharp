using DAL;
using Persistence;

namespace Test
{
    public class SearchBookByBookNameTest
    {
        BookDAL bookDal = new BookDAL();

        [Fact]
        public void SearchBookByBookNameTest1()
        {
            string keySearch = "tiếng anh";
            List<Book> result = bookDal.GetBookByBookName(keySearch);
            Assert.True(result != null);
        }

        [Fact]
        public void SearchBookByBookNameTest2()
        {
            string keySearch = "tài chính";
            List<Book> result = bookDal.GetBookByBookName(keySearch);
            Assert.True(result != null);
        }

        [Fact]
        public void SearchBookByBookNameTest3()
        {
            string keySearch = "sức khỏe";
            List<Book> result = bookDal.GetBookByBookName(keySearch);
            Assert.True(result != null);
        }


        [Theory]
        [InlineData("abc")]
        [InlineData("asdfg")]
        [InlineData("pf1304")]
        public void SearchBookByBookNameTest4(string keySearch)
        {
            List<Book> result = bookDal.GetBookByBookName(keySearch);
            Assert.True(result.Count == 0);
        }
    }
}