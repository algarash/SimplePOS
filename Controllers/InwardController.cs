using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SimplePOS.Controllers
{
    public class InwardController : Controller
    {
        private readonly IInwardRepository _inwardRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;

        public InwardController(IInwardRepository inwardRepository, IProductRepository productRepository, ISupplierRepository supplierRepository)
        {
            _inwardRepository = inwardRepository;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        public IActionResult Index()
        {
            var inwards = _inwardRepository.AllInwards;
            return View(inwards);
        }

        public IActionResult Details(int id)
        {
            var inward = _inwardRepository.GetInwardById(id);
            if (inward == null)
            {
                return NotFound();
            }
            return View(inward);
        }

        public IActionResult Create()
        {
            ViewBag.Products = new SelectList(_productRepository.AllProducts, "ProductId", "ProductName");
            ViewBag.Suppliers = new SelectList(_supplierRepository.AllSuppliers, "SupplierId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InwardCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var inward = new Inward
                {
                    SupplierId = model.SupplierId,
                    Date = model.Date,
                    InwardProducts = model.Products.Select(p => new InwardProduct
                    {
                        ProductId = p.ProductId,
                        Quantity = p.Quantity
                    }).ToList()
                };

                try
                {
                    _inwardRepository.AddInward(inward);
                    TempData["AlertMessage"] = "New inward transaction is added.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Handle the exception, e.g., log it and show an error message to the user
                    ModelState.AddModelError("", "An error occurred while saving the inward transaction.");
                }
            }

            ViewBag.Products = new SelectList(_productRepository.AllProducts, "ProductId", "ProductName");
            ViewBag.Suppliers = new SelectList(_supplierRepository.AllSuppliers, "SupplierId", "Name");
            return View(model);
        }


        public IActionResult Edit(int id)
        {
            var inward = _inwardRepository.GetInwardById(id);
            if (inward == null)
            {
                return NotFound();
            }

            var model = new InwardEditViewModel
            {
                InwardId = inward.InwardId,
                SupplierId = inward.SupplierId,
                Date = inward.Date,
                Products = inward.InwardProducts.Select(ip => new InwardProductViewModel
                {
                    ProductId = ip.ProductId,
                    Quantity = ip.Quantity
                }).ToList()
            };

            ViewBag.Products = new SelectList(_productRepository.AllProducts, "ProductId", "ProductName");
            ViewBag.Suppliers = new SelectList(_supplierRepository.AllSuppliers, "SupplierId", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InwardEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingInward = _inwardRepository.GetInwardById(model.InwardId);
                if (existingInward == null)
                {
                    return NotFound();
                }

                existingInward.SupplierId = model.SupplierId;
                existingInward.Date = model.Date;

                // Remove existing products
                existingInward.InwardProducts.Clear();

                // Add updated products
                existingInward.InwardProducts = model.Products.Select(p => new InwardProduct
                {
                    InwardId = model.InwardId,
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                }).ToList();

                _inwardRepository.UpdateInward(existingInward);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Products = new SelectList(_productRepository.AllProducts, "ProductId", "ProductName");
            ViewBag.Suppliers = new SelectList(_supplierRepository.AllSuppliers, "SupplierId", "Name");
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var inward = _inwardRepository.GetInwardById(id);
            if (inward == null)
            {
                return NotFound();
            }
            return View(inward);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _inwardRepository.DeleteInward(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
