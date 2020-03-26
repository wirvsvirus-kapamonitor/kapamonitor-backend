using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using KapaMonitor.Database;

namespace KapaMonitor.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LocationController> _logger;

        public DatabaseController(ApplicationDbContext context, ILogger<LocationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _context.Database.EnsureCreatedAsync();
            return Ok(_context.Database.CanConnect());
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            _context.Database.Migrate();
            return Ok();
        }
    }
}