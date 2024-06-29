using SimplePOS.Models;

namespace SimplePOS.ViewModels
{
    public class ProductUpdateViewModel
    {
        public Product? Product { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
