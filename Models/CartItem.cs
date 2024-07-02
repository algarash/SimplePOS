namespace SimplePOS.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
        public string? CartId { get; set; }

    }
}
