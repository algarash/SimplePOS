using Microsoft.AspNetCore.Mvc;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

namespace SimplePOS.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public IActionResult Index()
        {
            var suppliers = _supplierRepository.AllSuppliers;
            var viewModel = new SupplierListViewModel(suppliers, TempData["SupplierCreated"] as string);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View(new SupplierViewModel());
        }

        [HttpPost]
        public IActionResult Create(SupplierViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _supplierRepository.AddSupplier(viewModel.Supplier);
                TempData["SupplierCreated"] = "Supplier created successfully.";
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var supplier = _supplierRepository.GetSupplierById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            var viewModel = new SupplierViewModel
            {
                Supplier = supplier
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(SupplierViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _supplierRepository.UpdateSupplier(viewModel.Supplier);
                TempData["SupplierUpdated"] = "Supplier updated successfully.";
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            var supplier = _supplierRepository.GetSupplierById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _supplierRepository.DeleteSupplier(id);
            TempData["SupplierDeleted"] = "Supplier deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
