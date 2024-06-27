using Microsoft.EntityFrameworkCore;
using SimplePOS.Models.Repositories.Interfaces;

namespace SimplePOS.Models.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly SimplePOSContext _context;
        public ProductRepository(SimplePOSContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
               return _context.Products.Include(c => c.Category);
            }
        }
        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
