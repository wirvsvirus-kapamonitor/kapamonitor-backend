using KapaMonitor.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KapaMonitor.Application.ContactInfos
{
    public class GetContactInfo
    {
        private readonly ApplicationDbContext _context;

        public GetContactInfo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ContactInfoViewModel?> Do(int id)
        {
            var contactInfo = await _context.ContactInfos.FirstOrDefaultAsync(c => c.Id == id);

            if (contactInfo == null)
                return null;

            return new ContactInfoViewModel(contactInfo);
        }
    }
}
