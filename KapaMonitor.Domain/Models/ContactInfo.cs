using System.Collections.Generic;

namespace KapaMonitor.Domain.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Nullable for demo users
        public string FbUserId { get; set; }


        public IEnumerable<Location> Location { get; set; }
    }
}
