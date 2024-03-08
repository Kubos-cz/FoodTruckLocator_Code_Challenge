using Geolocation;

namespace FoodTruckLocator.Entities
{
    /// <summary>
    /// Food truck entity
    /// </summary>
    public class FoodTruckEntity
    {
        public string? Name { get; set; }

        public List<string>? FoodItems { get; set; }

        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        public string? DistanceinMiles { get; set; }
    }
}
