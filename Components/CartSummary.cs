using YuusufPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

namespace YuusufPieShop.Components
{
    public class CartSummary: ViewComponent
    {
        private readonly ICartRepository _cart;

        public CartSummary(ICartRepository cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _cart.GetCartItems();

            //var items = _shoppingCart.GetShoppingCartItems();
            _cart.CartItems = items;

            var cartViewModel = new CartViewModel(_cart, _cart.GetCartTotalPrice());

            return View(cartViewModel);
        }
    }
}
