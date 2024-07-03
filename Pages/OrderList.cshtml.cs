using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Interfaces;

namespace SimplePOS.Pages
{
    public class OrderListModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        public OrderListModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [BindProperty]
        public List<Order>? Orders { get; set; }
        public void OnGet()
        {
            Orders = _orderRepository.GetAllOrders().OrderByDescending(o => o.OrderId).ToList();
        }
    }
}
