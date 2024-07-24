namespace SimplePOS.Models.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> AllSuppliers { get; }
        Supplier? GetSupplierById(int id);
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
    }
}
