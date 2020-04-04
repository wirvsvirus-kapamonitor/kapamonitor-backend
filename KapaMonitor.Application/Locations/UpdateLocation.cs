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

        public async Task<(bool DbOpFailed, LocationViewModel? ViewModel)> Do(UpdateLocationRequest request)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(c => c.Id == request.Id);

            if (location == null)
                return (false, null);

            location.Title = request.Title;
            location.State = request.State;
            location.City = request.City;
            location.PostCode = request.PostCode;
            location.Street = request.Street;
            location.HouseNumber = request.HouseNumber;
            location.GeoLatitude = request.GeoLatitude;
            location.GeoLongitude = request.GeoLongitude;
            location.Accessability = request.Accessability;
            location.AccessToInternet = request.AccessToInternet;
            location.Url = request.Url;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await new ErrorLogging(_context).LogError(ErrorMessages.UpdateLocation, ex, request);
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
