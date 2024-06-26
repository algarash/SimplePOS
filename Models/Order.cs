namespace SimplePOS.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;

    }
}
