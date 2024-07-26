using Microsoft.EntityFrameworkCore;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

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
        // Add the method to get stock balances
        public IEnumerable<StockBalanceViewModel> GetStockBalances()
        {
            var stockBalances = _context.Products
                .Select(p => new StockBalanceViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    CategoryName = p.Category.CategoryName,
                    Inwards = _context.InwardProducts.Where(i => i.ProductId == p.ProductId).Sum(i => i.Quantity),
                    Outwards = _context.Outwards.Where(o => o.ProductId == p.ProductId).Sum(o => o.Quantity),
                    InHand = _context.InwardProducts.Where(i => i.ProductId == p.ProductId).Sum(i => i.Quantity) -
                             _context.Outwards.Where(o => o.ProductId == p.ProductId).Sum(o => o.Quantity)
                }).ToList();

            return stockBalances;
        }
    }
}
