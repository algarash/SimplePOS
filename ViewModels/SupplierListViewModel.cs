using SimplePOS.Models;

namespace SimplePOS.ViewModels
{
    public class SupplierListViewModel
    {
        public IEnumerable<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public string? Message { get; set; }

        public SupplierListViewModel()
        {
        }

        public SupplierListViewModel(IEnumerable<Supplier> suppliers, string? message = null)
        {
            Suppliers = suppliers;
            Message = message;
        }
    }
}
