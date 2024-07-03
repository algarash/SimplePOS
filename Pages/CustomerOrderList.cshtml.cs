using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Interfaces;

namespace SimplePOS.Pages
{
    public class CustomerOrderListModel : PageModel
    { 
        private readonly IOrderRepository _orderRepository;
        public CustomerOrderListModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [BindProperty]
        public List<Order>? Orders { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public void OnGet(int customerId, string customerName)
        {
            CustomerName = customerName;
            Orders = _orderRepository.GetAllCustomerOrders(customerId).OrderByDescending(o => o.OrderId).ToList();
        }
        public IActionResult OnPost(int customerId)
        {
            return Page();
        }
    }
}
