namespace Persistence
{

    public class Order
    {
        public int orderId { get; set; }
        public Customer? orderCustomer { get; set; }
        public Staff? orderStaff { get; set; }
        public Book? orderBook { get; set; }
        public DateTime orderDate { get; set; }
        public int orderStatus { get; set; }
        public decimal total { get; set; }
        public List<Book>? booksList { get; set; }

        public Order()
        {
            booksList = new List<Book>();
            orderCustomer = new Customer();
            orderStaff = new Staff();
            orderBook = new Book();
        }
    }
}