using Microsoft.EntityFrameworkCore;
using KapaMonitor.Domain.Models;
using KapaMonitor.Domain.Internal;

namespace KapaMonitor.Database
{
    public class ApplicationDbContext : DbContext
    {
        public object firstOrDefaultAsync;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<SanitaryInfo> SanitaryInfos { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        
        
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
