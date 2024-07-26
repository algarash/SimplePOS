using Microsoft.AspNetCore.Mvc;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

namespace SimplePOS.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IProductRepository _productRepository;

        public InventoryController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult StockBalance()
        {
            var stockBalances = _productRepository.GetStockBalances();
            return View(stockBalances);
        }
    }
}
