namespace Food_Ordering_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public string PaymentMode { get; set; }  // Cash / UPI
        public string? DeliveryAgent { get; set; }
    }
}
