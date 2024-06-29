using SimplePOS.Models;

namespace SimplePOS.ViewModels
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; } = new Product();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
