using Microsoft.AspNetCore.Mvc;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Interfaces;

namespace SimplePOS.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.NewCategory(category);
                TempData["AlertMessage"] = "Category created successfully";
                return RedirectToAction("Create","Product");
            }
            return View(category); // Re-render with errors and categories
        }
    }
}
