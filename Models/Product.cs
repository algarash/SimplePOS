using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SimplePOS.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        [Display(Name = "Product name")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Product Description")]
        public string?  ProductDescription { get; set; }

        [Required(ErrorMessage = "Please enter the product price")]
        public decimal Price { get; set; }

        [Display(Name = "Product Image Url")]
        [Required(ErrorMessage = "Product must have an Image")]
        public string? ProductImageUrl { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; } = default!;

        public List<OrderItem>? OrderItems { get; set; }
    }
}
