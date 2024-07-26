using System;
using System.ComponentModel.DataAnnotations;

namespace SimplePOS.Models
{
    public class Outward
    {
        public int OutwardId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order? Order { get; set; } = default!;

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; } = default!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } = default!;
    }
}
