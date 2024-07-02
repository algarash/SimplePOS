using Microsoft.AspNetCore.Mvc;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

namespace SimplePOS.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public CartController(IProductRepository producRepository, ICartRepository cartRepository)
        {
            _productRepository = producRepository;
            _cartRepository = cartRepository;
        }

        public ViewResult Index()
        {
            var items = _cartRepository.GetCartItems();
            _cartRepository.CartItems = items;

            var CartViewModel = new CartViewModel(_cartRepository,
                _cartRepository.GetCartTotalPrice());

            return View(CartViewModel);
        }

        public RedirectToActionResult AddToCart(int productId)
        {
            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId);

            if(ModelState.IsValid)
            {
                if (selectedProduct != null)
                {
                    TempData["ProductAdded"] = "Product is added to cart";
                    _cartRepository.AddToCart(selectedProduct);
                }
            }
            
            return RedirectToAction("ProductList","Product");

        }

        public RedirectToActionResult RemoveFromCart(int productId)
        {
            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId);

            if (selectedProduct != null)
            {
                TempData["ProductRemoved"] = "Product is removed from cart";
                _cartRepository.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("ProductList", "Product");

        }
        public RedirectToActionResult ClearCart()
        {
            TempData["CleanCart"] = "Cart is empty";

            _cartRepository.ClearCart();
            return RedirectToAction("ProductList","Product");
        }
    }
}
