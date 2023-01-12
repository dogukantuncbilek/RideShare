using AdessoRideShare.BL.City;
using AdessoRideShare.Common.Travel;
using city = AdessoRideShare.Common.City.City;
using travel = AdessoRideShare.Common.Travel.Travel;
namespace AdessoRideShare.BL.Travel
{
    public class TravelService : ITravelService
    {
        private List<travel> _travelList;
        private readonly ICityService _cityService;
        public TravelService(ICityService cityService)
        {
            this._travelList = new List<travel>();
            this._cityService = cityService;
        }
        public bool AddTravel(travel _travel)
        {
            try
            {
                _travelList.Add(new travel()
                {
                    AvailableSeats = _travel.AvailableSeats,
                    Description = _travel.Description,
                    IsPublished = _travel.IsPublished,
                    RoadPath = _travel.RoadPath,
                    StartDate = _travel.StartDate,
                    Id = Guid.NewGuid(),
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool PublishTravel(travel _travel)
        {
            var travel = _travelList.FirstOrDefault(x => x.Id.ToString() == _travel.Id.ToString());
            if (travel != null)
            {
                var indx = _travelList.IndexOf(travel);
                travel.IsPublished = true;
                _travelList[indx] = travel;
                return true;
            }
            return false;
        }
        public bool UnPublishTravel(travel _travel)
        {
            var travel = _travelList.FirstOrDefault(x => x.Id.ToString() == _travel.Id.ToString());
            if (travel != null)
            {
                var indx = _travelList.IndexOf(travel);
                travel.IsPublished = false;
                _travelList[indx] = travel;
                return true;
            }
            return false;
        }
        public List<city> GetCitiesOnRoad(RoadPath roadPath)
        {
            var cities = new List<city>();
            int x1 = roadPath.StartCity.Longitude;
            int y1 = roadPath.StartCity.Latitude;
            int x2 = roadPath.EndCity.Longitude;
            int y2 = roadPath.EndCity.Latitude;
            if (x1 == x2)
            {
                //road horizontal
                for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y += 50)
                {
                    var onRoadCity = _cityService.GetCityJustCoords(x1, y);
                    if (onRoadCity != null)
                        cities.Add(onRoadCity);
                }
            }
            else if (y1 == y2)
            {
                //road vertical
                for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x += 50)
                {
                    var onRoadCity = _cityService.GetCityJustCoords(x, y1);
                    if (onRoadCity != null)
                        cities.Add(onRoadCity);
                }
            }
            return cities;
        }
        public bool RequestSeat(RequestSeatModel seatModel)
        {
            var travel = _travelList.FirstOrDefault(x => x.Id.ToString() == seatModel.TravelId.ToString());
            if (travel != null)
            {
                var indx = _travelList.IndexOf(travel);
                if (travel.AvailableSeats >= seatModel.RequestedSeats)
                {
                    travel.AvailableSeats -= seatModel.RequestedSeats;
                    _travelList[indx] = travel;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public List<travel> SearchTravelOnRoad(DateTime startAt, RoadPath roadPath)
        {
            var citiesOnRoad = GetCitiesOnRoad(roadPath);
            var travels = _travelList.Where(x => x.StartDate >= startAt && x.IsPublished && citiesOnRoad.Contains(x.RoadPath.StartCity) && citiesOnRoad.Contains(x.RoadPath.EndCity)).ToList();
            return travels;
        }
    }
}
