using city = AdessoRideShare.Common.City.City;
namespace AdessoRideShare.BL.City
{
    public class CityService : ICityService
    {
        private List<city> _cityList;
        public CityService()
        {
            this._cityList = new List<city>();
        }
        public List<city> CityList() => this._cityList;
        public city GetCityJustCoords(int longitude, int latitude) => _cityList.FirstOrDefault(x => x.Longitude == longitude && x.Latitude == latitude);
        public city GetCityJustName(string name) => _cityList.FirstOrDefault(x => x.Name == name);
        public bool AddCity(city _city)
        {
            var ct = _cityList.FirstOrDefault(x => x.Name == _city.Name);
            if (ct == null)
            {
                _cityList.Add(_city);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
