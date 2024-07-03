namespace SimplePOS.Models.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order, int customerId);
        List<Order> GetAllCustomerOrders(int customerId);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);

    }
}
