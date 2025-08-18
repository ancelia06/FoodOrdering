namespace FoodOrdering__API.Models
{
    public class InvoiceItemDto
    {
        public int FoodItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal => Quantity * UnitPrice;
    }

    public class InvoiceDto
    {
        public int OrderId { get; set; }
        public List<InvoiceItemDto> Items { get; set; } = new();
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }
        public string PaymentMode { get; set; } = "cash";
        public string DeliveryPartner { get; set; } = "N/A";
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
