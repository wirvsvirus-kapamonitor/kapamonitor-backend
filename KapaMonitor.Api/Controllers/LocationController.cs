using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KapaMonitor.Database;
using KapaMonitor.Application.Locations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using KapaMonitor.Domain.Internal;
using static KapaMonitor.Application.Locations.CreateLocation;
using static KapaMonitor.Application.Locations.UpdateLocation;

namespace KapaMonitor.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all Locations
        /// </summary>
        /// <returns>All locations</returns>
        /// <response code="200">Returns all Locations as list</response>
        /// <response code="401">If the user is not logged in</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LocationViewModel>))]
        public async Task<IActionResult> Get()
        {
            var vms = await new GetLocations(_context).Do();
            return Ok(vms);
        }


        /// <summary>
        /// Returns a specific Location
        /// </summary>
        /// <param name="id">The id of the Location</param>
        /// <returns>The specified Location</returns>
        /// <response code="200">Returns the Location</response>
        /// <response code="401">If the user is not logged in</response>
        /// <response code="404">If the Location with the spezified id doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocationViewModel))]
        public async Task<IActionResult> Get(int id)
        {
            LocationViewModel? vm = await new GetLocation(_context).Do(id);

            if (vm == null)
                return NotFound();

            return Ok(vm);
        }

        /// <summary>
        /// Adds the transmitted Location to the database
        /// </summary>
        /// <param name="location">The Location to add</param>
        /// <returns>The the newly created Location</returns>
        /// <response code="200">Returns the newly created Location</response>
        /// <response code="401">If the user is not logged in</response>
        /// <response code="404">If the ContactInfo with the spezified id doesn't exist</response>
        /// <response code="500">If the database operation failed unexpectedly</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocationViewModel))]
        public async Task<IActionResult> Post([FromBody] CreateLocationRequest location)
        {
            (bool dbOpFailed, LocationViewModel? vm) = await new CreateLocation(_context).Do(location);

            if (dbOpFailed)
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.DatabaseOperationFailed);

            if (vm == null)
                return BadRequest();

            return Ok(vm);
        }

        /// <summary>
        /// Updates the transmitted Location in the database
        /// </summary>
        /// <param name="location">The Location to update. Ensure that the correct id was provided.</param>
        /// <returns>The the updated Location</returns>
        /// <response code="200">Returns the updated Location</response>
        /// <response code="401">If the user is not logged in</response>
        /// <response code="404">If the Location with the spezified id doesn't exist</response>
        /// <response code="500">If the database operation failed unexpectedly</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocationViewModel))]
        public async Task<IActionResult> Put([FromBody] UpdateLocationRequest location)
        {
            (bool dbOpFailed, LocationViewModel? vm) = await new UpdateLocation(_context).Do(location);

            if (dbOpFailed)
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.DatabaseOperationFailed);

            if (vm == null)
                return NotFound();

            return Ok(vm);
        }

        /// <summary>
        /// Removes the spezified Location from the database
        /// </summary>
        /// <param name="id">The id of the Location that should be removed</param>
        /// <response code="200">If the Location was removed</response>
        /// <response code="401">If the user is not logged in</response>
        /// <response code="404">If the Location with the spezified id doesn't exist</response>
        /// <response code="500">If the database operation failed unexpectedly</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            (bool dbOpFailed, bool succeeded) = await new DeleteLocation(_context).Do(id);

            if (dbOpFailed)
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.DatabaseOperationFailed);

            if (!succeeded)
                return NotFound();

            return Ok();
        }
    }
}
