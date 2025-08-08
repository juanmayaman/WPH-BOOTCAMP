using FoodOrderApi.Models;


namespace FoodOrderApi.Services
{
    public class DataStore
    {
        public List<FoodItem> FoodItems { get; set; } = new()
        {
            new FoodItem {Id = 1, Name = "Burger", Price = 99},
            new FoodItem {Id = 2, Name = "Pizza", Price = 199},
            new FoodItem {Id = 3, Name = "Fries", Price = 49},
            new FoodItem {Id = 2, Name = "Cola", Price = 30},
            new FoodItem {Id = 2, Name = "Ranch", Price = 20}
        };

        public List<Order> Orders { get; set; } = new();
    }
}
