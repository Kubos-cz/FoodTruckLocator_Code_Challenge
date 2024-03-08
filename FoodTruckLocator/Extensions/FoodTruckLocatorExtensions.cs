using FoodTruckLocator.Factories;
using FoodTruckLocator.Interfaces;
using FoodTruckLocator.Services;

namespace FoodTruckLocator.Extensions
{
    public static class FoodTruckLocatorExtensions
    {
        public static IServiceCollection AddFoodTruckLocatorServices(this IServiceCollection services)
        {
            // register factories
            services.AddTransient<IBasicFactory<HttpClient>, HttpClientFactory>();

            // register services
            services.AddScoped<LocatorService>();
            services.AddScoped<DataService>();

            return services;
        }
    }
}
