using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.Models;

namespace SimplePOS.Pages
{
    public class OrderDetailModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        public OrderDetailModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [BindProperty]
        public Order Order { get; set; } = default!;
        public int OrderId { get; set; }
        public void OnGet(int orderId)
        {
            OrderId = orderId;
            Order = _orderRepository.GetOrderById(OrderId);
        }
    }
}
