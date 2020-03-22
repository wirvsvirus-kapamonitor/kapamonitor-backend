using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WirVsVirus.Domain.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public double Area { get; set; }
        public int Beds { get; set; }
        public bool HeavyCurrent { get; set; }
        public double HeavyCurrentCapacity { get; set; }
        public int QuantityWaterConnections { get; set; }
        public bool BarrierFree { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
