using System.ComponentModel.DataAnnotations;

namespace SimplePOS.Models
{
    public class InwardProduct
    {
        public int InwardProductId { get; set; }

        [Required]
        public int InwardId { get; set; }
        public Inward Inward { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
