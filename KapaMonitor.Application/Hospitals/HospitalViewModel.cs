using KapaMonitor.Domain.Models;

namespace KapaMonitor.Application.Hospitals
{
    public class HospitalViewModel
    {
        public HospitalViewModel() { }

        public HospitalViewModel(Hospital hospital)
        {
            Id = hospital.Id;
            IkId = hospital.IkId;
            IsEmergencyHospital = hospital.IsEmergencyHospital;
            BedsWithVentilator = hospital.BedsWithVentilator;
            BedsWithoutVentilator = hospital.BedsWithoutVentilator;
            BarrierFree = hospital.BarrierFree;
            LocationId = hospital.LocationId;
        }

        public int Id { get; set; }
        public string? IkId { get; set; }
        public bool IsEmergencyHospital { get; set; }
        public int BedsWithVentilator { get; set; }
        public int BedsWithoutVentilator { get; set; }
        public bool BarrierFree { get; set; }

        public int LocationId { get; set; }
    }
}
