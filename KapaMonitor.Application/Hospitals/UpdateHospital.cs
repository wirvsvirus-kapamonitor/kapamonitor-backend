using KapaMonitor.Application.Services;
using KapaMonitor.Database;
using KapaMonitor.Domain.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KapaMonitor.Application.Hospitals
{
    public class UpdateHospital
    {
        private readonly ApplicationDbContext _context;

        public UpdateHospital(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool DbOpFailed, HospitalViewModel? ViewModel)> Do(UpdateHospitalRequest request)
        {
            var hospital = await _context.Hospitals.FirstOrDefaultAsync(c => c.Id == request.Id);

            if (hospital == null)
                return (false, null);

            hospital.IkId = request.IkId;
            hospital.IsEmergencyHospital = request.IsEmergencyHospital;
            hospital.BedsWithVentilator = request.BedsWithVentilator;
            hospital.BedsWithoutVentilator = request.BedsWithoutVentilator;
            hospital.BarrierFree = request.BarrierFree;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await new ErrorLogging(_context).LogError(ErrorMessages.UpdateHospital, ex, request);
                return (true, null);
            }

            return (false, new HospitalViewModel(hospital));
        }


        public class UpdateHospitalRequest
        {
            public int Id { get; set; }
            public string? IkId { get; set; }
            public bool IsEmergencyHospital { get; set; }
            public int BedsWithVentilator { get; set; }
            public int BedsWithoutVentilator { get; set; }
            public bool BarrierFree { get; set; }
        }
    }
}
