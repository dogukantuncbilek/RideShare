using System.Text.Json.Serialization;

namespace AdessoRideShare.Common.Travel
{
    public class RequestSeatModel
    {
        public Guid TravelId { get; set; }
        public int RequestedSeats { get; set; }

        [JsonConstructor]
        public RequestSeatModel()
        {

        }
    }
}
