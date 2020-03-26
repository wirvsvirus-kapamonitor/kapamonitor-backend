using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace KapaMonitor.Domain.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string IkId { get; set; }
        public bool IsEmergencyHospital { get; set; }
        public int BedsWithVentilator { get; set; }
        public int BedsWithoutVentilator { get; set; }
        public bool BarrierFree { get; set; }
        public string Url { get; set; }

        public int LocationId { get; set; }
        [JsonIgnore]
        public Location Location { get; set; }
    }
}
