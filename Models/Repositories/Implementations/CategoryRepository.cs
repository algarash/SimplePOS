using SimplePOS.Models.Repositories.Interfaces;

namespace SimplePOS.Models.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SimplePOSContext _context;
        public CategoryRepository(SimplePOSContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> AllCategories =>
            _context.Categories.OrderBy(c => c.CategoryName);

        public void NewCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}
