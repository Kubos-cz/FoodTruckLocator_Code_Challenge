namespace FoodTruckLocator.Inputs
{
    /// <summary>
    /// Input class for food truck search
    /// </summary>
    public class FoodTruckSearchInput
    {
        public required double Latitude { get; set; }

        public required double Longitude { get; set; }

        public required int NumberOfResults { get; set; }

        public List<string> PreferredFood { get; set; } = new List<string>();
    }
}
