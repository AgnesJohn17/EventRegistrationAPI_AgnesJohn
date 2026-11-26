
using Microsoft.AspNetCore.Mvc;
using EventRegistrationAPI_AgnesJohn.DTOs;
using EventRegistrationAPI_AgnesJohn.Services;

namespace EventRegistrationAPI_AgnesJohn.Controllers
{
    // Handles event registration and cancellation requests.
    [ApiController]
    [Route("api")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationsController(
            IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        // Returns all registrations for a specific event.
        [HttpGet("events/{id}/registrations")]
        public async Task<ActionResult<List<RegistrationDto>>>
            GetRegistrations(int id)
        {
            var registrations = await _registrationService
                .GetRegistrationsAsync(id);

            if (registrations == null)
            {
                return NotFound();
            }

            return Ok(registrations);
        }

        // Registers a student for an event.
        [HttpPost("events/{id}/registrations")]
        public async Task<ActionResult<RegistrationDto>> Register(
            int id, CreateRegistrationDto dto)
        {
            try
            {
                var registration = await _registrationService
                    .RegisterAsync(id, dto);

                return StatusCode(201, registration);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // Cancels an existing registration.
        [HttpDelete("registrations/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _registrationService
                .DeleteRegistrationAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
