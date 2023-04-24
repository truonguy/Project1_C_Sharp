using Persistence;
using DAL;

namespace BL
{
    public class OrderBL
    {
        private OrderDAL orderDal = new OrderDAL();

        public List<Order> GetOrderById(int keySearch)
        {
            return orderDal.GetOrderById(keySearch);
        }


        public bool CreateOrder(Order order)
        {
            return orderDal.CreateOrder(order);
        }

        public List<Order> GetAllPaidOrdersInDay()
        {
            return orderDal.GetAllPaidOrdersInDay();
        }

        public List<Order> GetAllUnpaidOrdersInDay()
        {
            return orderDal.GetAllUnpaidOrdersInDay();
        }

        public bool ChangeStatus(int orderId, bool check)
        {
            return orderDal.ChangeStatus(orderId, check);
        }

        public bool CancelPayment(List<Order> ordersList, bool check)
        {
            return orderDal.CancelPayment(ordersList, check);
        }
    }
}