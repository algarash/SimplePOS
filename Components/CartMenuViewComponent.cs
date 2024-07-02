using Microsoft.AspNetCore.Mvc;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

public class CartMenuViewComponent : ViewComponent
{
    private readonly IProductRepository _productRepository;
    private readonly ICartRepository _cartRepository;

    public CartMenuViewComponent(IProductRepository productRepository, ICartRepository cartRepository)
    {
        _productRepository = productRepository;
        _cartRepository = cartRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(int productId)
    {
        var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId);

        if (selectedProduct != null)
        {
            _cartRepository.AddToCart(selectedProduct);
        }

        var cartViewModel = new CartMenuViewModel
        {
            CartItems = _cartRepository.GetCartItems(),
            CartTotalPrice = _cartRepository.GetCartTotalPrice()
        };

        return View(cartViewModel); // Return the view component with updated cart data
    }
}