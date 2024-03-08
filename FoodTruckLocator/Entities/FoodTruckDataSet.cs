namespace FoodTruckLocator.Entities
{
    /// <summary>
    /// Food truck data set entity
    /// </summary>
    public class FoodTruckDataSet
    {
        public DateTime? CreatedAt { get; set; }

        public List<FoodTruckEntity>? FoodTrucks { get; set; }

    }
}
