using FoodOrdering__API.Models;

namespace FoodOrdering__API.Services
{
    public interface IOrderService
    {
        Order PlaceOrder(List<OrderItem> orderItems, string paymentMode);
        Order? GetOrderById(int id);
        List<Order> GetAllOrders();
    }
}
