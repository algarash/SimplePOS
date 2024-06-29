using System.ComponentModel.DataAnnotations;

namespace SimplePOS.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter category name")]
        public string CategoryName { get; set; } = string.Empty;
        public string? CategoryDescription { get; set; }
        public List<Product>? Products { get; set; }

    }
}
