using Ardalis.GuardClauses;
using FoodTruckLocator.Entities;
using FoodTruckLocator.Inputs;
using FoodTruckLocator.Outputs;
using Geolocation;

namespace FoodTruckLocator.Services
{
    public class LocatorService
    {
        /// <summary>
        /// Method to find food trucks based on search input 
        /// </summary>
        /// <typeparam name="searchInput">Search input object.</typeparam>
        /// <typeparam name="inputData">Source data input object.</typeparam>
        public FoodTruckSearchOutput FindFoodTrucks(FoodTruckSearchInput searchInput, FoodTruckDataSet inputData)
        {
            Guard.Against.Null(searchInput);
            Guard.Against.Null(searchInput.NumberOfResults);
            Guard.Against.Null(inputData);
            Guard.Against.Null(inputData.FoodTrucks);

            var userPosition = new Coordinate(searchInput.Latitude, searchInput.Longitude);
            List<FoodTruckEntity> filteredFoodTrucks;

            if (searchInput.PreferredFood.Count > 0)
            {
                // Filter food trucks based on preferred food items
                filteredFoodTrucks = inputData.FoodTrucks
                    .Where(truck => searchInput.PreferredFood
                        .Any(preferredFood => truck.FoodItems!.Contains(preferredFood.ToLower())))
                    .ToList();

                if(filteredFoodTrucks.Count == 0)
                {
                    return new FoodTruckSearchOutput();
                }
            }
            else
            {
                // If no preferred foods specified, use all food trucks
                filteredFoodTrucks = inputData.FoodTrucks.ToList();
            }

            // Calculate distances and limit the number of results
            var outputData = CalculateDistance(userPosition, searchInput.NumberOfResults, filteredFoodTrucks);

            return new FoodTruckSearchOutput(true, outputData);
        }

        /// <summary>
        /// Method to calculate distance to each trucks 
        /// </summary>
        /// <typeparam name="userCoordinate">Coordiante to calculate distance from.</typeparam>
        /// <typeparam name="top">Number of closest results we want to return</typeparam>
        /// <typeparam name="foodTrucks">List of foodtrucks</typeparam>
        private List<FoodTruckEntity> CalculateDistance(Coordinate userCoordinate, int top, List<FoodTruckEntity> foodTrucks)
        {
            Guard.Against.NullOrEmpty(foodTrucks);

            // Calculate distance to each truck
            foreach (var foodTruck in foodTrucks)
            {
                var truckCoordinate = new Coordinate(
                    double.TryParse(foodTruck.Latitude, out var latResult) ? latResult : 0.0,
                    double.TryParse(foodTruck.Longitude, out var longResult) ? longResult : 0.0);
                foodTruck.DistanceinMiles = GeoCalculator.GetDistance(userCoordinate, truckCoordinate).ToString();
            }

            // Sort By Distance, take specified amount of results
            var outputData = foodTrucks.OrderBy(x => x.DistanceinMiles ).Take(top).ToList();

            return outputData;
        }
    }
}
