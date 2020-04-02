using KapaMonitor.Application.Services;
using KapaMonitor.Database;
using KapaMonitor.Domain.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KapaMonitor.Application.Locations
{
    public class UpdateLocation
    {
        private readonly ApplicationDbContext _context;

        public UpdateLocation(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool DbOpFailed, LocationViewModel? ViewModel)> Do(UpdateLocationRequest vm)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(c => c.Id == vm.Id);

            if (location == null)
                return (false, null);

            location.Title = vm.Title;
            location.State = vm.State;
            location.City = vm.City;
            location.PostCode = vm.PostCode;
            location.Street = vm.Street;
            location.HouseNumber = vm.HouseNumber;
            location.GeoLatitude = vm.GeoLatitude;
            location.GeoLongitude = vm.GeoLongitude;
            location.Accessability = vm.Accessability;
            location.AccessToInternet = vm.AccessToInternet;
            location.Url = vm.Url;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await new ErrorLogging(_context).LogError(ErrorMessages.UpdateLocation, ex, vm);
                return (true, null);
            }

            return (false, new LocationViewModel(location));
        }

        public class UpdateLocationRequest
        {
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? State { get; set; }
            public string? City { get; set; }
            public string? PostCode { get; set; }
            public string? Street { get; set; }
            public string? HouseNumber { get; set; }
            public string? GeoLatitude { get; set; }
            public string? GeoLongitude { get; set; }
            public string? Accessability { get; set; }
            public bool AccessToInternet { get; set; }
            public string? Url { get; set; }
        }
    }
}
