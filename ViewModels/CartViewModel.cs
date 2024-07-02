using SimplePOS.Models.Repositories.Interfaces;

namespace SimplePOS.ViewModels
{
    public class CartViewModel
    {
        public CartViewModel(ICartRepository cart, decimal cartTotalPrice)
        {
            Cart = cart;
            CartTotalPrice = cartTotalPrice;
        }
        public ICartRepository Cart { get; }
        public decimal CartTotalPrice { get; }
    }
}
