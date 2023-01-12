using AdessoRideShare.Common.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace AdessoRideShare.BL.User
{
    public class UserService : IUserService
    {
        private List<RideShareUser> _users;
        private readonly IConfiguration _config;
        public UserService(IConfiguration configuration)
        {
            this._config = configuration;
            _users = new List<RideShareUser>();
        }
        public string SignIn(RideShareUserRequestModel signInRequestModel)
        {
            var user = _users.FirstOrDefault(x => x.Email == signInRequestModel.Email && x.Password == GetMD5Hashed(signInRequestModel.Password));
            if (user == null)
            {
                return String.Empty;
            }
            return CreateToken(user.Id);
        }

        public bool SignUp(RideShareUserRequestModel signUpRequestModel)
        {
            //todo custom responses
            if (_users.Any(x => x.Email == signUpRequestModel.Email))
            {
                return false;
            }
            try
            {
                _users.Add(new RideShareUser
                {
                    Email = signUpRequestModel.Email,
                    Id = Guid.NewGuid(),
                    Password = GetMD5Hashed(signUpRequestModel.Password),
                });
                return true;
            }
            catch (Exception ex)
            {
                //todo exception handling
                return false;
            }
        }

        #region Private Methods

        private string GetMD5Hashed(string val)
        {
            var hashedPassowrd = new StringBuilder();
            MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(val)).ToList().ForEach(x => hashedPassowrd.Append(x.ToString("x2")));
            return hashedPassowrd.ToString();
        }
        private string CreateToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = _config["JWT:Key"];
            var key = Encoding.ASCII.GetBytes(string.IsNullOrEmpty(jwtKey) ? "iouFYT37821941YXUZYTQWiii32894UYXzklm" : jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim("userId", userId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
