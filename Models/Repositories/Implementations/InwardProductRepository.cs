using Microsoft.EntityFrameworkCore;
using SimplePOS.Models.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SimplePOS.Models.Repositories.Implementations
{
    public class InwardProductRepository : IInwardProductRepository
    {
        private readonly SimplePOSContext _context;

        public InwardProductRepository(SimplePOSContext context)
        {
            _context = context;
        }

        public IEnumerable<InwardProduct> AllInwardProducts
        {
            get
            {
                return _context.InwardProducts
                    .Include(ip => ip.Inward)
                    .Include(ip => ip.Product)
                    .OrderBy(ip => ip.InwardProductId);
            }
        }

        public InwardProduct? GetInwardProductById(int id)
        {
            return _context.InwardProducts
                .Include(ip => ip.Inward)
                .Include(ip => ip.Product)
                .FirstOrDefault(ip => ip.InwardProductId == id);
        }

        public void AddInwardProduct(InwardProduct inwardProduct)
        {
            try
            {
                _context.InwardProducts.Add(inwardProduct);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the inward product.", ex);
            }
        }

        public void UpdateInwardProduct(InwardProduct inwardProduct)
        {
            try
            {
                _context.InwardProducts.Update(inwardProduct);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the inward product.", ex);
            }
        }

        public void DeleteInwardProduct(int id)
        {
            var inwardProduct = _context.InwardProducts.Find(id);
            if (inwardProduct != null)
            {
                _context.InwardProducts.Remove(inwardProduct);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}