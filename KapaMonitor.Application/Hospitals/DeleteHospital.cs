using KapaMonitor.Application.Services;
using KapaMonitor.Database;
using KapaMonitor.Domain.Internal;
using KapaMonitor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KapaMonitor.Application.Hospitals
{
    public class DeleteHospital
    {
        private readonly ApplicationDbContext _context;

        public DeleteHospital(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool DbOpFailed, bool Succeeded)> Do(int id)
        {
            var hospital = await _context.Hospitals.FirstOrDefaultAsync(c => c.Id == id);

            if (hospital == null)
                return (false, false);

            _context.Remove(hospital);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await new ErrorLogging(_context).LogError(ErrorMessages.DeleteHospital, ex);
                return (true, false);
            }

            return (false, true);
        }
    }
}
