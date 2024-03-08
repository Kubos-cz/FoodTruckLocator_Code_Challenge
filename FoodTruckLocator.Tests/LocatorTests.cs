using FoodTruckLocator.Services;
using FluentAssertions;
using Xunit;

namespace FoodTruckLocator.Tests
{
    public class LocatorTests
    {
        [Fact]
        public async Task DataService_ShouldGetData()
        {
            // Arrange
            var dataService = new DataService(new HttpClient());

            // Act
            var dataSet = await dataService.GetSourceData();

            // Assert
            dataSet.Should().NotBeNull();
            dataSet!.FoodTrucks.Should().NotBeNull();
            dataSet!.FoodTrucks!.Count.Should().BeGreaterThan(0);
        }
    }
}
