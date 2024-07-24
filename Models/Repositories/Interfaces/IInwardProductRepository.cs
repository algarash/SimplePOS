using System.Collections.Generic;

namespace SimplePOS.Models.Repositories.Interfaces
{
    public interface IInwardProductRepository
    {
        IEnumerable<InwardProduct> AllInwardProducts { get; }
        InwardProduct? GetInwardProductById(int id);
        void AddInwardProduct(InwardProduct inwardProduct);
        void UpdateInwardProduct(InwardProduct inwardProduct);
        void DeleteInwardProduct(int id);
        void Save();
    }
}
