using KapaMonitor.Application.Services;
using KapaMonitor.Database;
using KapaMonitor.Domain.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KapaMonitor.Application.ContactInfos
{
    public class UpdateContactInfo
    {
        private readonly ApplicationDbContext _context;

        public UpdateContactInfo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool DbOpFailed, ContactInfoViewModel? ViewModel)> Do(ContactInfoViewModel vm)
        {
            var contactInfo = await _context.ContactInfos.FirstOrDefaultAsync(c => c.Id == vm.Id);

            if (contactInfo == null)
                return (false, null);

            contactInfo.FirstName = vm.FirstName;
            contactInfo.LastName = vm.LastName;
            contactInfo.Email = vm.Email;
            contactInfo.Phone = vm.Phone;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await new ErrorLogging(_context).LogError(ErrorMessages.UpdateContactInfo, ex, vm);
                return (true, null);
            }

            return (false, new ContactInfoViewModel(contactInfo));
        }
    }
}
