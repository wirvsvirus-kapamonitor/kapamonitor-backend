using KapaMonitor.Application.Services;
using KapaMonitor.Database;
using KapaMonitor.Domain.Internal;
using KapaMonitor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KapaMonitor.Application.Locations
{
    public class DeleteLocation
    {
        private readonly ApplicationDbContext _context;

        public DeleteLocation(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool DbOpFailed, bool Succeeded)> Do(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(c => c.Id == id);

            if (location == null)
                return (false, false);

            _context.Remove(location);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await new ErrorLogging(_context).LogError(ErrorMessages.UpdateLocation, ex);
                return (true, false);
            }

            return (false, true);
        }
    }
}
