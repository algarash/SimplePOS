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
               return _context.Products.Include(c => c.Category).OrderByDescending(p => p.ProductId);
            }
        }

        public void AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                Save();
            }
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Save()
        { 
            _context.SaveChanges();
        }
    }
}
