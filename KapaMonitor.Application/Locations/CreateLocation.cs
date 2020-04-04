using KapaMonitor.Application.Services;
using KapaMonitor.Database;
using KapaMonitor.Domain.Internal;
using KapaMonitor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KapaMonitor.Application.Locations
{
    public class CreateLocation
    {
        private readonly ApplicationDbContext _context;

        public CreateLocation(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool DbOpFailed, LocationViewModel? ViewModel)> Do(CreateLocationRequest request)
        {
            ContactInfo contactInfo = await _context.ContactInfos.FirstOrDefaultAsync(c => c.Id == request.ContactInfoId);

            if (contactInfo == null)
                return (false, null);

            Location location = new Location
            {
                Title = request.Title,
                State = request.State,
                City = request.City,
                PostCode = request.PostCode,
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                GeoLatitude = request.GeoLatitude,
                GeoLongitude = request.GeoLongitude,
                Accessability = request.Accessability,
                AccessToInternet = request.AccessToInternet,
                Url = request.Url,

                ContactInfoId = request.ContactInfoId,
            };

            _context.Add(location);
            try
            {
                await _context.SaveChangesAsync();
            } 
            catch (Exception ex)
            {
                await new ErrorLogging(_context).LogError(ErrorMessages.CreateLocation, ex, request);
                return (true, null);
            }

            return (false, new LocationViewModel(location));
        }


        public class CreateLocationRequest
        {
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

            public int ContactInfoId { get; set; }
        }
    }
}
