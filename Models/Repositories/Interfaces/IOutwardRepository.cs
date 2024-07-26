namespace SimplePOS.Models.Repositories.Interfaces
{
    public interface IOutwardRepository
    {
        IEnumerable<Outward> GetAllOutwards();
        Outward GetOutwardById(int id); // New method to get an outward transaction by ID
        void CreateOutward(Outward outward);
    }
}
