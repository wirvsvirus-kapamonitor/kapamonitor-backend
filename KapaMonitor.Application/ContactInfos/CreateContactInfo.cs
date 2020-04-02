using KapaMonitor.Application.Services;
using KapaMonitor.Database;
using KapaMonitor.Domain.Internal;
using KapaMonitor.Domain.Models;
using System;
using System.Threading.Tasks;

namespace KapaMonitor.Application.ContactInfos
{
    public class CreateContactInfo
    {
        private readonly ApplicationDbContext _context;

        public CreateContactInfo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool DbOpFailed, ContactInfoViewModel? ViewModel)> Do(CreateContactInfoRequest request)
        {
            ContactInfo contactInfo = new ContactInfo
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
            };

            _context.Add(contactInfo);
            try
            {
                await _context.SaveChangesAsync();
            } 
            catch (Exception ex)
            {
                await new ErrorLogging(_context).LogError(ErrorMessages.CreateContactInfo, ex, request);
                return (true, null);
            }

            return (false, new ContactInfoViewModel(contactInfo));
        }


        public class CreateContactInfoRequest
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }
        }
    }
}
