using DAL;
using Persistence;

namespace Test
{
    public class SearchBookByCategoryNameTest
    {
        BookDAL bookDal = new BookDAL();

        [Fact]
        public void SearchBookByCategoryNameTest1()
        {
            string keySearch = "văn học";
            List<Book> result = bookDal.GetBookByCategoryName(keySearch);
            Assert.True(result != null);
        }

        [Fact]
        public void SearchBookByCategoryNameTest2()
        {
            string keySearch = "kinh tế";
            List<Book> result = bookDal.GetBookByCategoryName(keySearch);
            Assert.True(result != null);
        }

        [Fact]
        public void SearchBookByCategoryNameTest3()
        {
            string keySearch = "thiếu nhi";
            List<Book> result = bookDal.GetBookByCategoryName(keySearch);
            Assert.True(result != null);
        }


        [Theory]
        [InlineData("abc")]
        [InlineData("asdfg")]
        [InlineData("pf1304")]
        public void SearchBookByCategoryNameTest4(string keySearch)
        {
            List<Book> result = bookDal.GetBookByCategoryName(keySearch);
            Assert.True(result.Count == 0);
        }
    }
}