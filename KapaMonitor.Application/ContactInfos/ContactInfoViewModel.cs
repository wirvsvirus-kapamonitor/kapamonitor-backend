using KapaMonitor.Domain.Models;

namespace KapaMonitor.Application.ContactInfos
{
    public class ContactInfoViewModel
    {
        public ContactInfoViewModel() { }

        public ContactInfoViewModel(ContactInfo contactInfo)
        {
            Id = contactInfo.Id;
            FirstName = contactInfo.FirstName;
            LastName = contactInfo.LastName;
            Email = contactInfo.Email;
            Phone = contactInfo.Phone;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
