using FoodOrdering__API.Models;

namespace FoodOrdering__API.Services
{
    public interface IInvoiceService
    {
        InvoiceDto GenerateInvoice(Order order);
    }
}
