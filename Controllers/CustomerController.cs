using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Implementations;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

namespace SimplePOS.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public CustomerController(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult CustomerList()
        {

            IEnumerable<Customer> customers;
            customers = _customerRepository.GetAllCustomers;
            CustomerListViewModel customerListView = new CustomerListViewModel(
                customers);

            return View(customerListView);
        }
        public IActionResult AddCustomer (Customer customer)
        {
            if (ModelState.IsValid)
            {
                TempData["NewCustomer"] = "New customer is added";
                _customerRepository.AddCustomer(customer);
                return RedirectToAction("CustomerList");
            } 
            return View(customer);
        }

        public IActionResult UpdateCustomer(int id)
        {
            CustomerListViewModel viewModel = new CustomerListViewModel();
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }
            viewModel.Customer = customer;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(CustomerListViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var product = viewModel.Customer;
                _customerRepository.UpdateCustomer(product);
                TempData["CustomerUpdated"] = "Customer is updated successfully";
                return View(viewModel);
            }

            TempData["ErrorCustomerUpdate"] = "Error customer isn't updated";
            return View(viewModel);
        }

        public IActionResult DeleteCustomer(int id)
        {
            if(ModelState.IsValid)
            {
                TempData["CustomerDeleted"] = "Customer is deleted";
                _customerRepository.DeleteCustomer(id);
                return RedirectToAction("CustomerList");
            }
            return View();
        }
    }
}
