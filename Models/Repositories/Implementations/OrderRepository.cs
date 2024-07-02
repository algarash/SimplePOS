using SimplePOS.Models.Repositories.Interfaces;

namespace SimplePOS.Models.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SimplePOSContext _context;
        private readonly ICartRepository _cart;

        public OrderRepository(SimplePOSContext context, ICartRepository cart)
        {
            _context = context;
            _cart = cart;         
        }
        public void CreateOrder(Order order, int customerId)
        {
            order.OrderPlaced = DateTime.Now;

            List<CartItem>? cartItems = _cart.CartItems;
            order.OrderTotal = _cart.GetCartTotalPrice();

            order.OrderItems = new List<OrderItem>();

            foreach (CartItem? cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    Quantity = cartItem.Quantity,
                    ProductId = cartItem.Product.ProductId,
                };
                order.CustomerId = customerId;
                order.OrderItems.Add(orderItem);
                
            }
            _context.Orders.Add(order);
            _context.SaveChanges();


        }
    }
}
