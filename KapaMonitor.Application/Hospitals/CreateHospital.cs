using KapaMonitor.Application.Services;
using KapaMonitor.Database;
using KapaMonitor.Domain.Internal;
using KapaMonitor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KapaMonitor.Application.Hospitals
{
    public class CreateHospital
    {
        private readonly ApplicationDbContext _context;

        public CreateHospital(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool DbOpFailed, HospitalViewModel? ViewModel)> Do(CreateHospitalRequest request)
        {
            Location location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == request.LocationId);

            if (location == null)
                return (false, null);

            Hospital hospital = new Hospital
            {
                IkId = request.IkId,
                IsEmergencyHospital = request.IsEmergencyHospital,
                BedsWithVentilator = request.BedsWithVentilator,
                BedsWithoutVentilator = request.BedsWithoutVentilator,
                BarrierFree = request.BarrierFree,
                LocationId = request.LocationId,
            };

            _context.Add(hospital);
            try
            {
                await _context.SaveChangesAsync();

                location.HospitalId = hospital.Id;
                await _context.SaveChangesAsync();
            } 
            catch (Exception ex)
            {
                await new ErrorLogging(_context).LogError(ErrorMessages.CreateHospital, ex, request);
                return (true, null);
            }

            return (false, new HospitalViewModel(hospital));
        }


        public class CreateHospitalRequest
        {
            public string? IkId { get; set; }
            public bool IsEmergencyHospital { get; set; }
            public int BedsWithVentilator { get; set; }
            public int BedsWithoutVentilator { get; set; }
            public bool BarrierFree { get; set; }
            
            public int LocationId { get; set; }
        }
    }
}
