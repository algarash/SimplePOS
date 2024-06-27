using Microsoft.AspNetCore.Mvc;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

namespace SimplePOS.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductRepository _CategoryRepository;

        public ProductController(IProductRepository productRepository, IProductRepository categoryRepository)
        {
            _productRepository = productRepository;
            _CategoryRepository = categoryRepository;
        }

        public ViewResult ProductList()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel(
                _productRepository.AllProducts, "Milk");
            return View(productListViewModel);
        }
    }
}
