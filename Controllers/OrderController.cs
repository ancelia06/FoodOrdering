using Food_Ordering_API.Data;
using Food_Ordering_API.Models;
using Food_Ordering_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderService _orderService;

        public OrderController(ApplicationDbContext context, OrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult PlaceOrder(Order order)
        {
            // calculate total
            order.Total = order.Items.Sum(i =>
            {
                var menuItem = _context.Menu.Find(i.MenuItemId);
                return menuItem != null ? menuItem.Price * i.Quantity : 0;
            });

            order.Discount = _orderService.ApplyDiscount(order.Total);
            order.Total -= order.Discount;
            //order.DeliveryAgent = _orderService.AssignDeliveryAgent(_context.DeliveryAgents.ToList());
            order.DeliveryAgent = "Agent_" + Guid.NewGuid().ToString().Substring(0, 5);


            _context.Orders.Add(order);
            _context.SaveChanges();

            // print invoice to console
            Console.WriteLine("----- INVOICE -----");
            foreach (var item in order.Items)
            {
                var menu = _context.Menu.Find(item.MenuItemId);
                Console.WriteLine($"{menu?.Name} x {item.Quantity} = {menu?.Price * item.Quantity}");
            }
            Console.WriteLine($"Discount: {order.Discount}");
            Console.WriteLine($"Total: {order.Total}");
            Console.WriteLine($"Payment Mode: {order.PaymentMode}");
            Console.WriteLine($"Delivery Partner: {order.DeliveryAgent}");
            Console.WriteLine("-------------------");

            return Ok(order);
        }
    }
}
