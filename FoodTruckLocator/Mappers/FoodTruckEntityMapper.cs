using CsvHelper.Configuration;
using FoodTruckLocator.Entities;
using Geolocation;

namespace FoodTruckLocator.Mappers
{
    /// <summary>
    /// Food truck mapper for csv helper.
    /// </summary>
    public class FoodTruckEntityMapper : ClassMap<FoodTruckEntity>
    {
        public FoodTruckEntityMapper()
        {
            Map(x => x.Name).Index(1);
            Map(x => x.FoodItems).Index(11).Convert(row =>
                {
                    var columnValue = row.Row.GetField<string>("FoodItems");
                    return columnValue?.ToLower().Split(": ").ToList() ?? new List<string>();
                });
            Map(x => x.Latitude).Index(14);
            Map(x => x.Longitude).Index(15);
        }
    }
}
