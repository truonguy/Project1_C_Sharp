using Persistence;


namespace DAL
{
    public interface IOrderDAL
    {
        public List<Order> GetOrderById(int keySearch);
        public bool CreateOrder(Order order);
        public List<Order> GetAllPaidOrdersInDay();
        public List<Order> GetAllUnpaidOrdersInDay();
        public bool ChangeStatus(int orderId, bool check);
        public bool CancelPayment(List<Order> ordersList, bool check);
    }
}