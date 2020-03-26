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
    public class HospitalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LocationController> _logger;

        public HospitalController(ApplicationDbContext context, ILogger<LocationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Hospital>> Get()
        {
            return await _context.Hospitals.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Hospital> Get(int id)
        {
            return await _context.Hospitals.FirstAsync(h => h.Id == id);
        }

        [HttpPost]
        public async Task<Hospital> Post([Bind("IkId,IsEmergencyHospital,BedsWithVentilator,BedsWithoutVentilator,BarrierFree,Url")] Hospital hospital)
        {
            _context.Add(hospital);
            await _context.SaveChangesAsync();

            return hospital;
        }

        [HttpPut]
        public async Task<Hospital> Put([Bind("Id,IkId,IsEmergencyHospital,BedsWithVentilator,BedsWithoutVentilator,BarrierFree,Url")] Hospital hospital)
        {
            Hospital hospitalToUpdate = await _context.Hospitals.FirstAsync(h => h.Id == hospital.Id);

            hospitalToUpdate.IkId = hospital.IkId;
            hospitalToUpdate.IsEmergencyHospital = hospital.IsEmergencyHospital;
            hospitalToUpdate.BedsWithVentilator = hospital.BedsWithVentilator;
            hospitalToUpdate.BedsWithoutVentilator = hospital.BedsWithoutVentilator;
            hospitalToUpdate.BarrierFree = hospital.BarrierFree;
            hospitalToUpdate.Url = hospital.Url;

            await _context.SaveChangesAsync();

            return hospitalToUpdate;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _context.Hospitals.Remove(new Hospital() { Id = id });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
