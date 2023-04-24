using Persistence;


namespace DAL
{
    public interface IBookDAL
    {
        public Book GetBookById(int keySearch);
        public List<Book> GetBookByBookName(string keySearch);
        public List<Book> GetBookByCategoryName(string keySearch);
        public List<Book> GetAllBooks();
    }
}