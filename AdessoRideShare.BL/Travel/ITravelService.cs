using AdessoRideShare.Common.City;
using AdessoRideShare.Common.Travel;
using travel = AdessoRideShare.Common.Travel.Travel;
using city = AdessoRideShare.Common.City.City;
namespace AdessoRideShare.BL.Travel
{
    public interface ITravelService
    {
        public bool AddTravel(travel _travel);
        public bool PublishTravel(travel _travel);
        public bool UnPublishTravel(travel _travel);
        public List<travel> SearchTravelOnRoad(DateTime startAt, RoadPath roadPath);
        public List<city> GetCitiesOnRoad(RoadPath roadPath);
        public bool RequestSeat(RequestSeatModel seatModel);
    }
}
