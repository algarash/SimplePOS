using Microsoft.EntityFrameworkCore;
using SimplePOS.Models.Repositories.Interfaces;

namespace SimplePOS.Models.Repositories.Implementations
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SimplePOSContext _context;

        public SupplierRepository(SimplePOSContext context)
        {
            _context = context;
        }

        public IEnumerable<Supplier> AllSuppliers => _context.Suppliers.ToList();

        public Supplier? GetSupplierById(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }
    }
}
