using SimplePOS.Models;

namespace SimplePOS.ViewModels
{
    public class CustomerOrder
    {
        public Order? Order { get; set; }
        public int SelectedCustomerId { get; set; }
        public CustomerOrder(Order order, int selectedCustomer)
        {
            SelectedCustomerId = selectedCustomer;
            Order = order;
        }
    }
}
