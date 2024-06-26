namespace SimplePOS.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string? CustomerPhoto { get; set; }
        public List<Order>? Orders { get; set; }

    }
}
