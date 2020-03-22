using Microsoft.EntityFrameworkCore;
using WirVsVirus.Domain.Models;

namespace WirVsVirus.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<SanitaryInfo> SanitaryInfos { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
    }
}
