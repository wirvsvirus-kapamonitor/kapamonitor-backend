using KapaMonitor.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace KapaMonitor.Domain.Models
{
    public class Gym
    {
        // --- Database entity ---
        public int Id { get; set; }
        public double Area { get; set; }
        public int Beds { get; set; }
        public bool HeavyCurrent { get; set; }
        public double HeavyCurrentCapacity { get; set; }
        public int QuantityWaterConnections { get; set; }
        public bool BarrierFree { get; set; }

        [Required]
        public Location Location { get; set; }


        // --- Methods ---
        public LocationType LocationType => LocationType.Gym;
    }
}
