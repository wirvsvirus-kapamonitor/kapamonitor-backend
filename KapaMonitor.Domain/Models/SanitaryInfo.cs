using System.ComponentModel.DataAnnotations;

namespace KapaMonitor.Domain.Models
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

        [Required]
        public Location Location { get; set; }
    }
}
