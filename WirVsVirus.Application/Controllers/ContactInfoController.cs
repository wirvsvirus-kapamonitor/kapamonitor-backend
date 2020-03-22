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
    public class ContactInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LocationController> _logger;

        public ContactInfoController(ApplicationDbContext context, ILogger<LocationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactInfo>> Get()
        {
            return await _context.ContactInfos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ContactInfo> Get(int id)
        {
            return await _context.ContactInfos.FirstAsync(c => c.Id == id);
        }

        [HttpPost]
        public async Task<ContactInfo> Post([Bind("FirstName,LastName,Email,Phone")] ContactInfo contactInfo)
        {
            _context.Add(contactInfo);
            await _context.SaveChangesAsync();

            return contactInfo;
        }

        [HttpPut]
        public async Task<ContactInfo> Put([Bind("Id,FirstName,LastName,Email,Phone")] ContactInfo contactInfo)
        {
            ContactInfo contactInfoToUpdate = await _context.ContactInfos.FirstAsync(c => c.Id == contactInfo.Id);

            contactInfoToUpdate.FirstName = contactInfo.FirstName;
            contactInfoToUpdate.LastName = contactInfo.LastName;
            contactInfoToUpdate.Email = contactInfo.Email;
            contactInfoToUpdate.Phone = contactInfo.Phone;

            await _context.SaveChangesAsync();

            return contactInfoToUpdate;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _context.ContactInfos.Remove(new ContactInfo() { Id = id });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
