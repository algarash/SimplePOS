namespace SimplePOS.Models.Repositories.Interfaces
{
    public interface ICartRepository
    {
        void AddToCart(Product product);
        int RemoveFromCart(Product product);
        List<CartItem> GetCartItems();
        void ClearCart();
        decimal GetCartTotalPrice();
        List<CartItem> CartItems { get; set; }
    }
}
