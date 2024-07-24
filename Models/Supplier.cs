using System.ComponentModel.DataAnnotations;

namespace SimplePOS.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Please enter supplier name")]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Contact Info")]
        public string? ContactInfo { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }
    }
}
