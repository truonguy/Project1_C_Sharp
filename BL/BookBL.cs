using Persistence;
using DAL;


namespace BL
{
    public class BookBL
    {
        private BookDAL bookDal = new BookDAL();

        public Book GetBookById(int keySearch)
        {
            return bookDal.GetBookById(keySearch);
        }

        public List<Book> GetBookByBookName(string keySearch)
        {
            return bookDal.GetBookByBookName(keySearch);
        }

        public List<Book> GetBookByCategoryName(string keySearch)
        {
            return bookDal.GetBookByCategoryName(keySearch);
        }

        public List<Book> GetAllBooks()
        {
            return bookDal.GetAllBooks();
        }
    }
}