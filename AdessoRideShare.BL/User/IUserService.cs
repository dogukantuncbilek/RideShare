using AdessoRideShare.Common.User;
namespace AdessoRideShare.BL.User
{
    public interface IUserService
    {
        public bool SignUp(RideShareUserRequestModel signUpRequestModel);
        public string SignIn(RideShareUserRequestModel signInRequestModel);
    }
}
