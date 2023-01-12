using AdessoRideShare.BL.User;
using AdessoRideShare.Common.General;
using AdessoRideShare.Common.User;
using Microsoft.AspNetCore.Mvc;

namespace AdessoRideShare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }
        [HttpPost("sign-up")]
        public IActionResult SignUp([FromBody] RideShareUserRequestModel model)
        {
            var retVal = new WebApiResponseMessage<bool>();
            try
            {
                var result = userService.SignUp(model);
                if (result)
                {
                    retVal.Data = true;
                    retVal.Header.RetCode = 1;
                    retVal.Header.Message = "Sign-up success";

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
        [HttpPost("sign-in")]
        public IActionResult SignIn([FromBody] RideShareUserRequestModel model)
        {
            var retVal = new WebApiResponseMessage<string>();
            try
            {
                var result = userService.SignIn(model);
                if (!string.IsNullOrEmpty(result))
                {
                    retVal.Data = result;
                    retVal.Header.RetCode = 1;
                    retVal.Header.Message = "Sign-in success";

                }
                else
                {
                    retVal.Data = string.Empty;
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
