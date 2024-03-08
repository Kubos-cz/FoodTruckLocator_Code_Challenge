using Ardalis.GuardClauses;
using CsvHelper;
using CsvHelper.Configuration;
using FoodTruckLocator.Entities;
using FoodTruckLocator.Interfaces;
using FoodTruckLocator.Mappers;
using System.Globalization;

namespace FoodTruckLocator.Services
{
    /// <summary>
    /// Service to obtain source data and create dataset for application.
    /// </summary>
    public class DataService : IDataService<FoodTruckDataSet>
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {


            _httpClient = httpClient;
        }

        public DataService(IBasicFactory<HttpClient> httpClientFactory) 
        {
            Guard.Against.Null(httpClientFactory);

            _httpClient = httpClientFactory.Create();
        }

        public async Task<FoodTruckDataSet?> GetSourceData()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Comment = '#',
                AllowComments = false,
                Delimiter = ",",
            };

            using (var stream = await _httpClient.GetStreamAsync("https://data.sfgov.org/api/views/rqzj-sfat/rows.csv?accessType=DOWNLOAD"))
            using (var streamReader = new StreamReader(stream))
            using (var csv = new CsvReader(streamReader, csvConfig))
            {
                csv.Context.RegisterClassMap<FoodTruckEntityMapper>();
                var dataSet = new FoodTruckDataSet()
                {
                    CreatedAt = DateTime.Now,
                    FoodTrucks = csv.GetRecords<FoodTruckEntity>().ToList()
                };
                return dataSet;
            }
        }
    }
}
