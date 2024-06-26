namespace SimplePOS.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal TotalPrice => Quantity * Product.Price;

    }
}
