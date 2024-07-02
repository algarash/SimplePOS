using SimplePOS.Models;

namespace SimplePOS.ViewModels
{
    public class CartMenuViewModel
    {
        public List<CartItem> CartItems { get; set; } = default!;
        public decimal CartTotalPrice { get; set; }
    }
}
