using KapaMonitor.Application.Services;
using KapaMonitor.Database;
using KapaMonitor.Domain.Internal;
using KapaMonitor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KapaMonitor.Application.ContactInfos
{
    public class DeleteContactInfo
    {
        private readonly ApplicationDbContext _context;

        public DeleteContactInfo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool DbOpFailed, bool Succeeded)> Do(int id)
        {
            var contactInfo = await _context.ContactInfos.FirstOrDefaultAsync(c => c.Id == id);

            if (contactInfo == null)
                return (false, false);

            _context.Remove(contactInfo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await new ErrorLogging(_context).LogError(ErrorMessages.DeleteContactInfo, ex);
                return (true, false);
            }

            return (false, true);
        }
    }
}
