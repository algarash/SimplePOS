using SimplePOS.Models;

namespace SimplePOS.ViewModels
{
    public class CustomerListViewModel
    {
        public CustomerListViewModel(IEnumerable<Customer> customers)
        {
            Customers = customers;
        }
        public CustomerListViewModel(IEnumerable<Customer> customers, Order order)
        {
            Customers = customers;
            Order = order;
        }
        public CustomerListViewModel()
        {
        }
        public Order? Order { get; set; }
        public int SelectedCustomerId { get; set; }
        public Customer? Customer{ get; set; }
        public IEnumerable<Customer> Customers{ get; set; } = new List<Customer>();
    }
}
