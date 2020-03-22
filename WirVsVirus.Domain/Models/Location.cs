using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace WirVsVirus.Domain.Models
{
    public class Location
    {
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
        [JsonIgnore]
        public ContactInfo ContactInfo { get; set; }

        [JsonIgnore]
        public SanitaryInfo SanitaryInfo { get; set; }

        [JsonIgnore]
        public Gym Gym { get; set; }
        [JsonIgnore]
        public Hotel Hotel { get; set; }
        [JsonIgnore]
        public Hospital Hospital { get; set; }
    }
}

