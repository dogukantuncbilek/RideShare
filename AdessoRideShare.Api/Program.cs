using AdessoRideShare.BL.City;
using AdessoRideShare.BL.Travel;
using AdessoRideShare.BL.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ICityService, CityService>();
builder.Services.AddSingleton<ITravelService, TravelService>();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();