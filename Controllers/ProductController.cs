using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;
using System.IO.Pipelines;

namespace SimplePOS.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult ProductList(string category)
        {
            IEnumerable<Product> products;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.AllProducts.OrderByDescending(p => p.ProductId);
                currentCategory = "All products";
            }
            else
            {
                products = _productRepository.AllProducts.Where(p =>
                    p.Category?.CategoryName == category)
                        .OrderByDescending(p => p.ProductId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c =>
                c.CategoryName == category)?.CategoryName;
            }
            ProductListViewModel productListViewModel = new ProductListViewModel(
                products, currentCategory);

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
            var categories = _categoryRepository.AllCategories.OrderByDescending(c => c.CategoryId).ToList(); // Get all categories
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
            var categories = _categoryRepository.AllCategories.OrderByDescending(c => c.CategoryId).ToList(); // Get all categories
            viewModel.Categories =  categories;
            return View(viewModel); // Re-render with errors and categories
        }

        public IActionResult Update(int id)
        {
            ProductCreateViewModel viewModel = new ProductCreateViewModel();
            var product = _productRepository.GetProductById(id);
            var categories = _categoryRepository.AllCategories.OrderByDescending(c => c.CategoryId).ToList(); // Get all categories

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
