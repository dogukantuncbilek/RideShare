using System.Text.Json.Serialization;

namespace AdessoRideShare.Common.Travel
{
    public class SearchTravelModel
    {
        public string StartCityName { get; set; }
        public string EndCityName { get; set; }
        public int StartCityLongitude { get; set; }
        public int StartCityLatitude { get; set; }
        public int EndCityLongitude { get; set; }
        public int EndCityLatitude { get; set; }
        public DateTime StartDate { get; set; }

        [JsonConstructor]
        public SearchTravelModel()
        {

        }
    }
}
