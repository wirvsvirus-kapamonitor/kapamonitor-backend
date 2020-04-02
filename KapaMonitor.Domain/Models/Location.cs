using KapaMonitor.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace KapaMonitor.Domain.Models
{
    public class Location
    {
        // --- Database entity ---
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

        public int ContactInfoId { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public int? GymId { get; set; }
        public Gym Gym { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int? HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public int? SanitaryInfoId { get; set; }
        public SanitaryInfo SanitaryInfo { get; set; }


        // --- Methods ---
        public LocationType LocationType
        {
            get
            {
                if (Gym != null)
                    return LocationType.Gym;
                else if (Hotel != null)
                    return LocationType.Hotel;
                else if (Hospital != null)
                    return LocationType.Hospital;
                else
                    throw new NullReferenceException();
            }
        }
    }
}

