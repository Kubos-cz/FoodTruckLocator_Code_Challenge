using Ardalis.GuardClauses;
using FoodTruckLocator.Entities;
using FoodTruckLocator.Inputs;
using FoodTruckLocator.Outputs;
using FoodTruckLocator.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodTruckLocator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodTruckLocatorController : Controller
    {
        ///<summary>
        /// Locate trucks based on my search
        ///</summary>
        [HttpPost]
        [AllowAnonymous]
        [Route("Search")]
        [SwaggerOperation(Summary = "Locate trucks based on my search")]
        [ProducesResponseType(typeof(List<FoodTruckSearchOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FoodTruckSearchOutput), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodTruckSearchOutput>> ListBusiness(
            [FromBody] FoodTruckSearchInput searchInput,
            [FromServices] DataService dataService,
            [FromServices] LocatorService locatorService)
        {
            Guard.Against.Null(searchInput);
            Guard.Against.Null(searchInput.Latitude);
            Guard.Against.Null(searchInput.Longitude);
            Guard.Against.Null(searchInput.NumberOfResults);

            var dataSet = await dataService.GetSourceData();
            var searchOutput = locatorService.FindFoodTrucks(searchInput, dataSet);

            if (searchOutput.HasResults)
            {
                return Ok(searchOutput);
            }
            else
            {
                return NotFound("No trucks with your specified food were found.");
            }
        }
    }
}
