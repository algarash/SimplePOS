using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

namespace SimplePOS.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly SimplePOSContext _context;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, SimplePOSContext context)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _context = context;
        }

        public IActionResult ProductList()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel(
                _productRepository.AllProducts, "All Products");

            return View(productListViewModel);
        }
        
        public IActionResult ProductDetail(int id)
        {
           var product = _productRepository.GetProductById(id);
            if(product == null)
                return NotFound();
            return View(product);
        }


        public IActionResult Create()
        {
            var categories = _context.Categories.OrderByDescending(c => c.CategoryId).ToList(); // Get all categories
            var viewModel = new ProductCreateViewModel { Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var selectedCategoryId = viewModel.Product.CategoryId;
                viewModel.Product.CategoryId = selectedCategoryId;

                _productRepository.AddProduct(viewModel.Product);
                TempData["ProductCreated"] = "New Product is Added";
                return RedirectToAction("ProductList");
            }
            var categories = _context.Categories.OrderByDescending(c => c.CategoryId).ToList(); // Get all categories
            viewModel.Categories =  categories;
            return View(viewModel); // Re-render with errors and categories
        }

        public IActionResult Update(int id)
        {
            ProductCreateViewModel viewModel = new ProductCreateViewModel();
            var product = _productRepository.GetProductById(id);
            var categories = _context.Categories.OrderByDescending(c => c.CategoryId).ToList(); // Get all categories

            if (product == null)
            {
                return NotFound();
            }
            viewModel.Product = product;
            viewModel.Categories = categories;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(ProductCreateViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var product = viewModel.Product;
                _productRepository.UpdateProduct(product);
                TempData["ProductUpdated"] = "Product is updated successfully";
                return View(viewModel);
            }

            TempData["ErrorProductUpdated"] = "Error product isn't updated";
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            TempData["ProductDeleted"] = "Product is deleted";
            return RedirectToAction("ProductList");
        }

    }
}
