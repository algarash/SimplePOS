namespace SimplePOS.Models.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product? GetProductById(int id);
    }
}
