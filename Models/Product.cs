namespace SimplePOS.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string?  ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ProductImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
