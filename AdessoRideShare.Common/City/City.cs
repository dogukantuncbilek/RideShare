using System.Text.Json.Serialization;

namespace AdessoRideShare.Common.City
{
    [Serializable]
    public class City
    {
        public string Name { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public City(string name, int longitude, int latitude)
        {
            this.Name = name;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
        public City(int longitude, int latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
        public City(string name)
        {
            this.Name = name;
        }
        [JsonConstructor]

        public City()
        {

        }
    }
}
