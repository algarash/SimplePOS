using System.ComponentModel.DataAnnotations;

namespace SimplePOS.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First name")]
        public string CustomerFirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last name")]
        public string CustomerLastName { get; set; } = string.Empty;

        [Display(Name = "Customer photo Url")]
        public string? CustomerPhoto { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
