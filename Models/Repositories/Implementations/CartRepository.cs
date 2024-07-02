using Microsoft.EntityFrameworkCore;
using SimplePOS.Models.Repositories.Interfaces;
using System;
using System.IO.Pipelines;

namespace SimplePOS.Models.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly SimplePOSContext _context;

        public List<CartItem> CartItems { get; set; } = default!;

        public string? CartId { get; set; }
        public CartRepository(SimplePOSContext context)
        {
            _context = context;
        }
        public static CartRepository GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>
                ()?.HttpContext?.Session;

            SimplePOSContext context = services.GetRequiredService<SimplePOSContext>
                () ?? throw new Exception("Error initialization");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new CartRepository(context) { CartId = cartId };
        }
        public void AddToCart(Product product)
        {
            var cartItem =
                _context.CartItems.FirstOrDefault(
                    s => s.Product.ProductId == product.ProductId && s.CartId == CartId);

            if (cartItem == null)
            {

                cartItem = new CartItem
                {
                    CartId = CartId,
                    Product = product,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = _context
                .CartItems
                .Where(cart => cart.CartId ==CartId);

            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems ??= _context.CartItems.Where(c =>
            c.CartId == CartId).
            Include(s => s.Product).
            ToList();
        }

        public decimal GetCartTotalPrice()
        {
            var total = _context.CartItems.Where(c =>
            c.CartId == CartId).
            Select(c => c.Product.Price * c.Quantity).Sum();

            return total;
        }

        public int RemoveFromCart(Product product)
        {
            var CartItem =
                 _context.CartItems.FirstOrDefault(
                     s => s.Product.ProductId== product.ProductId && s.CartId == CartId);
            var localAmount = 0;
            if (CartItem != null)
            {
                if (CartItem.Quantity > 1)
                {
                    CartItem.Quantity--;
                    localAmount = CartItem.Quantity;
                }
                else
                {
                    _context.CartItems.Remove(CartItem);

                }
            }
            _context.SaveChanges();
            return localAmount;
        }
    }
}
