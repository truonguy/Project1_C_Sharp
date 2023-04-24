namespace Persistence
{

    public class Book
    {
        public int bookId { get; set; }
        public Category? bookCategory { get; set; }
        public string? bookName { get; set; }
        public string? authorName { get; set; }
        public decimal bookPrice { get; set; }
        public string? bookDescription { get; set; }
        public int bookQuantity { get; set; }
        public decimal bookAmount { get; set; }

        public Book()
        {
            bookCategory = new Category();
        }
    }
}