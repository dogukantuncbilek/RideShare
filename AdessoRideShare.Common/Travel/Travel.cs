using System.Text.Json.Serialization;

namespace AdessoRideShare.Common.Travel
{
    public class Travel
    {
        public Guid Id { get; set; }
        public RoadPath RoadPath { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public int AvailableSeats { get; set; }
        public bool IsPublished { get; set; }

        [JsonConstructor]
        public Travel()
        {

        }
    }
}
