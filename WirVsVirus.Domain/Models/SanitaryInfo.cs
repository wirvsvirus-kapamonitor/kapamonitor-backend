using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace WirVsVirus.Domain.Models
{
    public class SanitaryInfo
    {
        public int Id { get; set; }
        public int QuantitySinks { get; set; }
        public int QuantityShowers { get; set; }
        public int QuantityToilents { get; set; }
        public int QuantityBathrooms { get; set; }
        public int Floor { get; set; }
        public bool BarrierFree { get; set; }

        public int LocationId { get; set; }
        [JsonIgnore]
        public Location Location { get; set; }
    }
}
