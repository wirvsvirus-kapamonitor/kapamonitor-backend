using KapaMonitor.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace KapaMonitor.Domain.Models
{
    public class Hospital
    {
        // --- Database entity ---
        public int Id { get; set; }
        public string IkId { get; set; }
        public bool IsEmergencyHospital { get; set; }
        public int BedsWithVentilator { get; set; }
        public int BedsWithoutVentilator { get; set; }
        public bool BarrierFree { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }


        // --- Methods ---
        public LocationType LocationType => LocationType.Hospital;
    }
}
