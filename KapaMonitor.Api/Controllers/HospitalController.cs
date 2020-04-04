using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KapaMonitor.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using KapaMonitor.Application.Hospitals;
using KapaMonitor.Domain.Internal;
using static KapaMonitor.Application.Hospitals.CreateHospital;
using static KapaMonitor.Application.Hospitals.UpdateHospital;

namespace KapaMonitor.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class HospitalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HospitalController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a specific Hospital
        /// </summary>
        /// <param name="id">The id of the Hospital</param>
        /// <returns>The specified Hospital</returns>
        /// <response code="200">Returns the Hospital</response>
        /// <response code="401">If the user is not logged in</response>
        /// <response code="404">If the Hospital with the spezified id doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HospitalViewModel))]
        public async Task<IActionResult> Get(int id)
        {
            HospitalViewModel? vm = await new GetHospital(_context).Do(id);

            if (vm == null)
                return NotFound();

            return Ok(vm);
        }

        /// <summary>
        /// Adds the transmitted Hospital to the database
        /// </summary>
        /// <param name="hospital">The Hospital to add</param>
        /// <returns>The the newly created Hospital</returns>
        /// <response code="200">Returns the newly created Hospital</response>
        /// <response code="401">If the user is not logged in</response>
        /// <response code="404">If the Location with the spezified id doesn't exist</response>
        /// <response code="500">If the database operation failed unexpectedly</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HospitalViewModel))]
        public async Task<IActionResult> Post([FromBody] CreateHospitalRequest hospital)
        {
            (bool dbOpFailed, HospitalViewModel? vm) = await new CreateHospital(_context).Do(hospital);

            if (dbOpFailed)
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.DatabaseOperationFailed);

            if (vm == null)
                return BadRequest();

            return Ok(vm);
        }

        /// <summary>
        /// Updates the transmitted Hospital in the database
        /// </summary>
        /// <param name="hospital">The Hospital to update. Ensure that the correct id was provided.</param>
        /// <returns>The the updated Hospital</returns>
        /// <response code="200">Returns the updated Hospital</response>
        /// <response code="401">If the user is not logged in</response>
        /// <response code="404">If the Hospital with the spezified id doesn't exist</response>
        /// <response code="500">If the database operation failed unexpectedly</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HospitalViewModel))]
        public async Task<IActionResult> Put([FromBody] UpdateHospitalRequest hospital)
        {
            (bool dbOpFailed, HospitalViewModel? vm) = await new UpdateHospital(_context).Do(hospital);

            if (dbOpFailed)
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.DatabaseOperationFailed);

            if (vm == null)
                return NotFound();

            return Ok(vm);
        }

        /// <summary>
        /// Removes the spezified Hospital from the database
        /// </summary>
        /// <param name="id">The id of the Hospital that should be removed</param>
        /// <response code="200">If the Hospital was removed</response>
        /// <response code="401">If the user is not logged in</response>
        /// <response code="404">If the Hospital with the spezified id doesn't exist</response>
        /// <response code="500">If the database operation failed unexpectedly</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            (bool dbOpFailed, bool succeeded) = await new DeleteHospital(_context).Do(id);

            if (dbOpFailed)
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.DatabaseOperationFailed);

            if (!succeeded)
                return NotFound();

            return Ok();
        }
    }
}
