using Microsoft.AspNetCore.Mvc;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

namespace SimplePOS.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cart;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOutwardRepository _outwardRepository;

        public OrderController(IOrderRepository orderRepository, ICartRepository cart,
            ICustomerRepository customerRepository, IOutwardRepository outwardRepository)
        {
            _orderRepository = orderRepository;
            _cart = cart;
            _customerRepository = customerRepository;
            _outwardRepository = outwardRepository;
        }

        public IActionResult Checkout()
        {
            var customers = _customerRepository.GetAllCustomers;
            var customerListView = new CustomerListViewModel(customers);
            return View(customerListView);
        }

        [HttpPost]
        public IActionResult Checkout(CustomerListViewModel cartOrder)
        {
            cartOrder.Customers = _customerRepository.GetAllCustomers;
            var items = _cart.GetCartItems();
            _cart.CartItems = items;
            var order = new Order();
            var customerId = cartOrder.SelectedCustomerId;

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some items");
            }

            if (ModelState.IsValid)
            {
                TempData["OrderCreated"] = "Order is Created";
                _orderRepository.CreateOrder(order, customerId);

                // Create outward transactions
                foreach (var item in _cart.CartItems)
                {
                    var outward = new Outward
                    {
                        OrderId = order.OrderId,
                        ProductId = item.Product.ProductId,
                        Quantity = item.Quantity,
                        Date = DateTime.Now,
                        CustomerId = customerId
                    };
                    _outwardRepository.CreateOutward(outward);
                }

                _cart.ClearCart();
                return RedirectToAction("ProductList", "Product");
            }

            TempData["OrderError"] = "Something went wrong";
            return View(cartOrder);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy your items.";
            return View();
        }
    }
}
