using FoodOrdering__API.Data;
using FoodOrdering__API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering__API.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;
        public OrderService(AppDbContext db) => _db = db;

        public Order PlaceOrder(List<OrderItem> orderItems, string paymentMode)
        {
            // Snapshot prices from menu
            foreach (var it in orderItems)
            {
                var food = _db.FoodItems.AsNoTracking().FirstOrDefault(f => f.Id == it.FoodItemId);
                if (food is null) throw new ArgumentException($"Food item {it.FoodItemId} not found.");
                it.Price = food.Price;
            }

            var total = orderItems.Sum(i => i.Price * i.Quantity);

            var order = new Order
            {
                Items = orderItems,
                PaymentMode = paymentMode,
                Discount = 0,
                TotalAmount = total,
                DeliveryPartner = _db.DeliveryAgents.AsNoTracking().FirstOrDefault()?.Name ?? "N/A",
                CreatedAt = DateTime.UtcNow
            };

            _db.Orders.Add(order);
            _db.SaveChanges();
            return order;
        }

        public Order? GetOrderById(int id) => _db.Orders
        .Include(o => o.Items)
            .ThenInclude(i => i.FoodItem) 
        .AsNoTracking()
        .FirstOrDefault(o => o.Id == id);

        public List<Order> GetAllOrders() =>
            _db.Orders
                .Include(o => o.Items)
                    .ThenInclude(i => i.FoodItem) 
                .AsNoTracking()
                .OrderByDescending(o => o.Id)
                .ToList();

    }
}
