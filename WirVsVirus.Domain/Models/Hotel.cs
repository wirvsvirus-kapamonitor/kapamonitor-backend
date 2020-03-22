using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace WirVsVirus.Domain.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public int BedsWithVentilatorWithCarpet { get; set; }
        public int BedsWithoutVentilatorWithCarpet { get; set; }
        public int BedsWithVentilatorOtherFLoor { get; set; }
        public bool HeavyCurrent { get; set; }
        public double HeavyCurentCapacity { get; set; }
        public int KitchenCapacity { get; set; }
        public string FireProtectionsRegulations { get; set; }

        public int LocationId { get; set; }
        [JsonIgnore]
        public Location Location { get; set; }
    }
}
