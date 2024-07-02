namespace SimplePOS.Models.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order, int customerId);
    }
}
