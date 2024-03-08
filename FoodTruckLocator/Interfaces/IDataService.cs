using FoodTruckLocator.Entities;

namespace FoodTruckLocator.Interfaces
{
    public interface IDataService<T>
    {
        public Task<T?> GetSourceData();
    }
}
