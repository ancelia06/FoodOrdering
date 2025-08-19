using Food_Ordering_API.Models;

namespace Food_Ordering_API.Services
{
    public class OrderService
    {
        private readonly Random _random = new Random();

        public decimal ApplyDiscount(decimal total)
        {
            return total > 500 ? 50 : 0;
        }

        public string AssignDeliveryAgent(List<DeliveryAgent> agents)
        {
            if (agents.Count == 0) return "No Agent Available";
            int index = _random.Next(agents.Count);
            return agents[index].Name;
        }
    }

}
