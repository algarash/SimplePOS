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
    }
}
