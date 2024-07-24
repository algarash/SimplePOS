using System.Collections.Generic;

namespace SimplePOS.Models.Repositories.Interfaces
{
    public interface IInwardRepository
    {
        IEnumerable<Inward> AllInwards { get; }
        Inward? GetInwardById(int id);
        void AddInward(Inward inward);
        void UpdateInward(Inward inward);   
        void DeleteInward(int id);
        void Save();
    }
}
