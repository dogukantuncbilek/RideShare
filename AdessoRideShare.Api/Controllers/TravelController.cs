using AdessoRideShare.BL.City;
using AdessoRideShare.BL.Travel;
using AdessoRideShare.Common.General;
using AdessoRideShare.Common.Travel;
using Microsoft.AspNetCore.Mvc;
using city = AdessoRideShare.Common.City.City;
namespace AdessoRideShare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService travelService;
        private readonly ICityService cityService;
        public TravelController(ITravelService _travelService, ICityService _cityService)
        {
            this.travelService = _travelService;
            this.cityService = _cityService;
        }
        [HttpPost("add-travel")]
        public IActionResult AddTravel([FromBody] Travel travelModel)
        {
            var retVal = new WebApiResponseMessage<bool>();
            try
            {
                var result = travelService.AddTravel(travelModel);
                if (result)
                {
                    retVal.Data = true;
                    retVal.Header.RetCode = 1;
                    retVal.Header.Message = "Travel adding success";

                }
                else
                {
                    retVal.Data = false;
                    retVal.Header.RetCode = 0;
                    retVal.Header.Message = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                //todo exception handling
                return StatusCode(500);
            }
            return Ok(retVal);
        }
        [HttpPost("publish-travel")]
        public IActionResult PublishTravel([FromBody] Travel travelModel)
        {
            var retVal = new WebApiResponseMessage<bool>();
            try
            {
                var result = travelService.PublishTravel(travelModel);
                if (result)
                {
                    retVal.Data = true;
                    retVal.Header.RetCode = 1;
                    retVal.Header.Message = $"{travelModel.Id} is Published";

                }
                else
                {
                    retVal.Data = false;
                    retVal.Header.RetCode = 0;
                    retVal.Header.Message = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                //todo exception handling
                return StatusCode(500);
            }
            return Ok(retVal);
        }
        [HttpPost("unpublish-travel")]
        public IActionResult UnpublishTravel([FromBody] Travel travelModel)
        {
            var retVal = new WebApiResponseMessage<bool>();
            try
            {
                var result = travelService.AddTravel(travelModel);
                if (result)
                {
                    retVal.Data = true;
                    retVal.Header.RetCode = 1;
                    retVal.Header.Message = $"{travelModel.Id} is UnPublished";

                }
                else
                {
                    retVal.Data = false;
                    retVal.Header.RetCode = 0;
                    retVal.Header.Message = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                //todo exception handling
                return StatusCode(500);
            }
            return Ok(retVal);
        }
        [HttpPost("search-travels-coords")]
        public IActionResult SearchTravelsWithCoords([FromBody] SearchTravelModel searchModel)
        {
            var retVal = new WebApiResponseMessage<List<Travel>>();
            try
            {
                var startCity = new city(searchModel.StartCityLongitude, searchModel.StartCityLatitude);
                var endCity = new city(searchModel.EndCityLongitude, searchModel.EndCityLatitude);
                var roadPath = new RoadPath(startCity, endCity);
                var travels = travelService.SearchTravelOnRoad(searchModel.StartDate, roadPath);
                if (travels.Count > 0)
                {
                    retVal.Data = travels;
                    retVal.Header.RetCode = 1;
                    retVal.Header.Message = $"{travels.Count} Travels found.";

                }
                else
                {
                    retVal.Data = new List<Travel>();
                    retVal.Header.RetCode = 0;
                    retVal.Header.Message = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                //todo exception handling
                return StatusCode(500);
            }
            return Ok(retVal);
        }
        [HttpPost("search-travels-names")]
        public IActionResult SearchTravelsWithNames([FromBody] SearchTravelModel searchModel)
        {
            var retVal = new WebApiResponseMessage<List<Travel>>();
            try
            {
                var startCity = cityService.GetCityJustName(searchModel.StartCityName);
                var endCity = cityService.GetCityJustName(searchModel.EndCityName);
                var roadPath = new RoadPath(startCity, endCity);
                var travels = travelService.SearchTravelOnRoad(searchModel.StartDate, roadPath);
                if (travels.Count > 0)
                {
                    retVal.Data = travels;
                    retVal.Header.RetCode = 1;
                    retVal.Header.Message = $"{travels.Count} Travels found.";

                }
                else
                {
                    retVal.Data = new List<Travel>();
                    retVal.Header.RetCode = 0;
                    retVal.Header.Message = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                //todo exception handling
                return StatusCode(500);
            }
            return Ok(retVal);
        }

        [HttpPost("request-seat")]
        public IActionResult RequestSeat([FromBody] RequestSeatModel requestModel)
        {
            var retVal = new WebApiResponseMessage<bool>();
            try
            {
                var result = travelService.RequestSeat(requestModel);
                if (result)
                {
                    retVal.Data = true;
                    retVal.Header.RetCode = 1;
                    retVal.Header.Message = "Seat reservation success.";

                }
                else
                {
                    retVal.Data = false;
                    retVal.Header.RetCode = 0;
                    retVal.Header.Message = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                //todo exception handling
                return StatusCode(500);
            }
            return Ok(retVal);
        }
    }
}
