using AdessoRideShare.BL.City;
using AdessoRideShare.Common.City;
using AdessoRideShare.Common.General;
using Microsoft.AspNetCore.Mvc;

namespace AdessoRideShare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;
        public CityController(ICityService _cityService)
        {
            this.cityService = _cityService;
        }
        [HttpPost("add-city")]
        public IActionResult AddCity([FromBody] City city)
        {
            var retVal = new WebApiResponseMessage<bool>();
            try
            {
                var result = cityService.AddCity(city);
                if (result)
                {
                    retVal.Data = true;
                    retVal.Header.RetCode = 1;
                    retVal.Header.Message = "City adding success";

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
