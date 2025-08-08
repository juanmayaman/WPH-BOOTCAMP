namespace FoodOrderApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<int> FoodItemIds { get; set; } = new();
        public DateTime OrderTime { get; set; } = DateTime.Now;
    }
}
