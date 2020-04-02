using KapaMonitor.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KapaMonitor.Application.Locations
{
    public class GetLocations
    {
        private readonly ApplicationDbContext _context;

        public GetLocations(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LocationViewModel>> Do()
        {
            var locations = await _context.Locations.Select(l => new LocationViewModel(l)).ToListAsync();

            return locations;
        }
    }
}
