namespace FoodOrdering__API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public string PaymentMode { get; set; }
        public string DeliveryPartner { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
