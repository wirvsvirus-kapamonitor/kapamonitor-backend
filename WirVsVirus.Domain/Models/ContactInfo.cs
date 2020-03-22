using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WirVsVirus.Domain.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        [JsonIgnore]
        public IEnumerable<Location> Location { get; set; }
    }
}
