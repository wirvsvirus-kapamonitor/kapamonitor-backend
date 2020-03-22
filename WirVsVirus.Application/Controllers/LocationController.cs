using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WirVsVirus.Database;
using WirVsVirus.Domain.Models;

namespace WirVsVirus.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ApplicationDbContext context, ILogger<LocationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<LocationJsonModel>> Get()
        {
            return await _context.Locations
                .Include(l => l.SanitaryInfo)
                .Include(l => l.Gym)
                .Include(l => l.Hotel)
                .Include(l => l.Hospital)
                .Take(200)
                .Select(l => new LocationJsonModel(l)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Location> Get(int id)
        {
            return await _context.Locations.FirstAsync(l => l.Id == id);
        }

        [HttpPost]
        public async Task<Location> Post([Bind("Title,State,City,PostCode,Street,HouseNumber,GeoLatitude,GeoLongitude,Accessability,AccessToInternet,ContactInfoId,Url")] Location location)
        {
            _context.Add(location);
            await _context.SaveChangesAsync();

            return location;
        }

        [HttpPut]
        public async Task<Location> Put([Bind("Id,Title,State,City,PostCode,Street,HouseNumber,GeoLatitude,GeoLongitude,Accessability,AccessToInternet,ContactInfoId,Url")] Location location)
        {
            Location locationToUpdate = await _context.Locations.FirstAsync(l => l.Id == location.Id);

            locationToUpdate.City = location.City;
            locationToUpdate.PostCode = location.PostCode;
            locationToUpdate.Street = location.Street;
            locationToUpdate.HouseNumber = location.HouseNumber;
            locationToUpdate.Accessability = location.Accessability;
            locationToUpdate.AccessToInternet = location.AccessToInternet;

            await _context.SaveChangesAsync();

            return locationToUpdate;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _context.Locations.Remove(new Location() { Id = id });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
