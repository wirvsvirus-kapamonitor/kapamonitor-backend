using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using KapaMonitor.Database;
using KapaMonitor.Domain.Models;

namespace KapaMonitor.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LocationController> _logger;

        public HotelController(ApplicationDbContext context, ILogger<LocationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Hotel>> Get()
        {
            return await _context.Hotels.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Hotel> Get(int id)
        {
            return await _context.Hotels.FirstAsync(h => h.Id == id);
        }

        [HttpPost]
        public async Task<Hotel> Post(
            [Bind("BedsWithVentilatorWithCarpet,BedsWithoutVentilatorWithCarpet,BedsWithVentilatorOtherFLoor," +
            "HeavyCurrent,HeavyCurentCapacity,KitchenCapacity,FireProtectionsRegulations")] Hotel hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }

        [HttpPut]
        public async Task<Hotel> Put(
            [Bind("Id,BedsWithVentilatorWithCarpet,BedsWithoutVentilatorWithCarpet,BedsWithVentilatorOtherFLoor," +
            "HeavyCurrent,HeavyCurentCapacity,KitchenCapacity,FireProtectionsRegulations")] Hotel hotel)
        {
            Hotel hotelToUpdate = await _context.Hotels.FirstAsync(h => h.Id == hotel.Id);

            hotelToUpdate.BedsWithVentilatorWithCarpet = hotel.BedsWithVentilatorWithCarpet;
            hotelToUpdate.BedsWithoutVentilatorWithCarpet = hotel.BedsWithoutVentilatorWithCarpet;
            hotelToUpdate.BedsWithVentilatorOtherFLoor = hotel.BedsWithVentilatorOtherFLoor;
            hotelToUpdate.HeavyCurrent = hotel.HeavyCurrent;
            hotelToUpdate.HeavyCurentCapacity = hotel.HeavyCurentCapacity;
            hotelToUpdate.KitchenCapacity = hotel.KitchenCapacity;
            hotelToUpdate.FireProtectionsRegulations = hotel.FireProtectionsRegulations;

            await _context.SaveChangesAsync();

            return hotelToUpdate;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _context.Hotels.Remove(new Hotel() { Id = id });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
