using System.Text.Json.Serialization;
using city = AdessoRideShare.Common.City.City;
namespace AdessoRideShare.Common.Travel
{
    public class RoadPath
    {
        public city StartCity { get; set; }
        public city EndCity { get; set; }

        public RoadPath(city startCity, city endCity)
        {
            StartCity = startCity;
            EndCity = endCity;
        }

        [JsonConstructor]
        public RoadPath()
        {

        }
    }
}
