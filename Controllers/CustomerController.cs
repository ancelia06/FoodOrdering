using FoodOrdering__API.Models;
using FoodOrdering__API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering__API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IOrderService _orderService;
        private readonly IInvoiceService _invoiceService;

        public CustomerController(IMenuService menuService, IOrderService orderService, IInvoiceService invoiceService)
        {
            _menuService = menuService;
            _orderService = orderService;
            _invoiceService = invoiceService;
        }

        [HttpGet("menu")]
        public ActionResult<List<FoodItem>> GetMenu() => _menuService.GetMenu();

        [HttpPost("order")]
        public ActionResult<object> PlaceOrder([FromBody] OrderRequest request)
        {
            var order = _orderService.PlaceOrder(request.Items, request.PaymentMode);
            var invoice = _invoiceService.GenerateInvoice(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, new { order, invoice });
        }

        [HttpGet("order/{id:int}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order is null) return NotFound();
            return order;
        }

        [HttpGet("orders")]
        public ActionResult<List<Order>> GetOrders() => _orderService.GetAllOrders();
    }

    public class OrderRequest
    {
        public List<OrderItem> Items { get; set; } = new();
        public string PaymentMode { get; set; } = "cash";
    }
}
