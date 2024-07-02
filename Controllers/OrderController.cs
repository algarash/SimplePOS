using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;
using YuusufPieShop.Models;

namespace YuusufPieShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cart;
        private readonly ICustomerRepository _customerRepository;

        public OrderController(IOrderRepository orderRepository, ICartRepository cart,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _cart = cart;
            _customerRepository = customerRepository;
        }
        public IActionResult Checkout()
        {
            IEnumerable<Customer> customers;
            customers = _customerRepository.GetAllCustomers;
            CustomerListViewModel customerListView = new CustomerListViewModel(
                customers);
            return View(customerListView);
        }

        [HttpPost]
        public IActionResult Checkout(CustomerListViewModel cartOrder)
        {            
            cartOrder.Customers = _customerRepository.GetAllCustomers;
            var items = _cart.GetCartItems();
            _cart.CartItems = items;
            cartOrder.Order = new Order();
            var order = cartOrder.Order;
            var customerId = cartOrder.SelectedCustomerId;

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty , add some pies");
            }
            if (ModelState.IsValid)
            {
                TempData["OrderCreated"] = "Order is Created";
                _orderRepository.CreateOrder(order, customerId);
                _cart.ClearCart();
                return RedirectToAction("ProductList", "Product");
            }
            TempData["OrderError"] = "Something wrong";
            return View(cartOrder);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy your pies ";
            return View();
        }
    }
}
