using FoodOrdering__API.Models;

namespace FoodOrdering__API.Services
{
    public class InvoiceService : IInvoiceService
    {
        public InvoiceDto GenerateInvoice(Order order)
        {
            var items = order.Items.Select(i => new InvoiceItemDto
            {
                FoodItemId = i.FoodItemId,
                Name = i.FoodItem?.Name ?? $"Item {i.FoodItemId}",
                Quantity = i.Quantity,
                UnitPrice = i.Price
            }).ToList();

            var subtotal = items.Sum(x => x.LineTotal);

            return new InvoiceDto
            {
                OrderId = order.Id,
                Items = items,
                Subtotal = subtotal,
                Discount = order.Discount,
                FinalAmount = subtotal - order.Discount,
                PaymentMode = order.PaymentMode,
                DeliveryPartner = order.DeliveryPartner,
                Date = DateTime.UtcNow
            };
        }
    }
}
