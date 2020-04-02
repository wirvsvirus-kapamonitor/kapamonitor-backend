using KapaMonitor.Domain.Models;

namespace KapaMonitor.Application.Locations
{
    public class LocationViewModel
    {
        public LocationViewModel(Location location)
        {
            Id = location.Id;
            Title = location.Title;
            State = location.State;
            City = location.City;
            PostCode = location.PostCode;
            Street = location.Street;
            HouseNumber = location.HouseNumber;
            GeoLatitude = location.GeoLatitude;
            GeoLongitude = location.GeoLongitude;
            Accessability = location.Accessability;
            AccessToInternet = location.AccessToInternet;
            Url = location.Url;

            ContactInfoId = location.ContactInfoId;
            SanitaryInfoId = location.SanitaryInfoId;
            GymId = location.GymId;
            HotelId = location.HotelId;
            HospitalId = location.HospitalId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string GeoLatitude { get; set; }
        public string GeoLongitude { get; set; }
        public string Accessability { get; set; }
        public bool AccessToInternet { get; set; }
        public string Url { get; set; }

        public int? ContactInfoId { get; set; }

        public int? GymId { get; set; }
        public int? HotelId { get; set; }
        public int? HospitalId { get; set; }

        public int? SanitaryInfoId { get; set; }

        public Domain.Enums.LocationType LocationType
        {
            get {
                if (GymId > 0)
                    return Domain.Enums.LocationType.Gym;
                else if (HotelId > 0)
                    return Domain.Enums.LocationType.Hotel;
                else if (HospitalId > 0)
                    return Domain.Enums.LocationType.Hospital;

                return 0;
            }
        }
    }
}

