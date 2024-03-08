using FoodTruckLocator.Interfaces;

namespace FoodTruckLocator.Factories
{
    /// <summary>
    /// Factory class for http client creation.
    /// </summary>
    public class HttpClientFactory : IBasicFactory<HttpClient>
    {
        public HttpClient Create()
        {
            return new HttpClient();
        }
    }
}
