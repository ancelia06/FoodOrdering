namespace Food_Ordering_API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
