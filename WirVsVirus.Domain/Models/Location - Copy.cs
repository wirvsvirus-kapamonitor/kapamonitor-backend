using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace WirVsVirus.Domain.Models
{
    public class LocationJsonModel
    {
        public LocationJsonModel(Location location)
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

            SanitaryInfo = location.SanitaryInfo;
            Gym = location.Gym;
            Hotel = location.Hotel;
            Hospital = location.Hospital;
            
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

        public ContactInfo ContactInfo { get; set; }
        public SanitaryInfo SanitaryInfo { get; set; }
        public Gym Gym { get; set; }
        public Hotel Hotel { get; set; }
        public Hospital Hospital { get; set; }

        public string Type {
            get {
                if (SanitaryInfo != null)
                    return nameof(SanitaryInfo);
                else if (Gym != null)
                    return nameof(Gym);
                else if (Hotel != null)
                    return (nameof(Hotel));
                else if (Hospital != null)
                    return (nameof(Hospital));

                return "unknown";
            }
        }
    }
}

