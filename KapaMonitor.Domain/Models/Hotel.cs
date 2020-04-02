using KapaMonitor.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace KapaMonitor.Domain.Models
{
    public class Hotel
    {
        // --- Database entity ---
        public int Id { get; set; }
        public int BedsWithVentilatorWithCarpet { get; set; }
        public int BedsWithoutVentilatorWithCarpet { get; set; }
        public int BedsWithVentilatorOtherFLoor { get; set; }
        public int BedsWithoutVentilatorOtherFLoor { get; set; }
        public bool HeavyCurrent { get; set; }
        public double HeavyCurentCapacity { get; set; }
        public int KitchenCapacity { get; set; }
        public string FireProtectionsRegulations { get; set; }

        [Required]
        public Location Location { get; set; }


        // --- Methods ---
        public LocationType LocationType => LocationType.Hotel;
    }
}
