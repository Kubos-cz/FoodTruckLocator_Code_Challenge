using FoodTruckLocator.Entities;

namespace FoodTruckLocator.Outputs
{
    /// <summary>
    /// Output class for food truck search
    /// </summary>
    public class FoodTruckSearchOutput
    {
        public FoodTruckSearchOutput() 
        {
            HasResults = false;
        }

        public FoodTruckSearchOutput(bool hasResults, List<FoodTruckEntity> foodTrucks)
        {
            HasResults = hasResults;
            FoodTrucks = foodTrucks;
        }

        public bool HasResults { get; set; }
        public List<FoodTruckEntity>? FoodTrucks { get; set; }
    }
}
