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
    public class SanitaryInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LocationController> _logger;

        public SanitaryInfoController(ApplicationDbContext context, ILogger<LocationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<SanitaryInfo>> Get()
        {
            return await _context.SanitaryInfos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<SanitaryInfo> Get(int id)
        {
            return await _context.SanitaryInfos.FirstAsync(s => s.Id == id);
        }

        [HttpPost]
        public async Task<SanitaryInfo> Post(
            [Bind("QuantitySinks,QuantityShowers,QuantityToilents,QuantityBathrooms,Floor,BarrierFree,LocationId")] SanitaryInfo sanitaryInfo)
        {
            _context.Add(sanitaryInfo);
            await _context.SaveChangesAsync();

            return sanitaryInfo;
        }

        [HttpPut]
        public async Task<SanitaryInfo> Put(
            [Bind("Id,QuantitySinks,QuantityShowers,QuantityToilents,QuantityBathrooms,Floor,BarrierFree,LocationId")] SanitaryInfo sanitaryInfo)
        {
            SanitaryInfo sanitaryInfoToUpdate = await _context.SanitaryInfos.FirstAsync(s => s.Id == sanitaryInfo.Id);

            sanitaryInfoToUpdate.QuantitySinks = sanitaryInfo.QuantitySinks;
            sanitaryInfoToUpdate.QuantityShowers = sanitaryInfo.QuantityShowers;
            sanitaryInfoToUpdate.QuantityToilents = sanitaryInfo.QuantityToilents;
            sanitaryInfoToUpdate.QuantityBathrooms = sanitaryInfo.QuantityBathrooms;
            sanitaryInfoToUpdate.Floor = sanitaryInfo.Floor;
            sanitaryInfoToUpdate.BarrierFree = sanitaryInfo.BarrierFree;

            await _context.SaveChangesAsync();

            return sanitaryInfoToUpdate;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _context.SanitaryInfos.Remove(new SanitaryInfo() { Id = id });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
