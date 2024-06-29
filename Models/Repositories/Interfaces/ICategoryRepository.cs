namespace SimplePOS.Models.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        public void NewCategory(Category category);
    }
}
