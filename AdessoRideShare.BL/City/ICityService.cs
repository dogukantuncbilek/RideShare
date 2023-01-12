using city = AdessoRideShare.Common.City.City;
namespace AdessoRideShare.BL.City
{
    public interface ICityService
    {
        public List<city> CityList();
        public city GetCityJustCoords(int longitude, int latitude);
        public city GetCityJustName(string name);
        public bool AddCity(city _city);
    }
}
