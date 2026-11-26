
using Microsoft.AspNetCore.Mvc;
using EventRegistrationAPI_AgnesJohn.DTOs;
using EventRegistrationAPI_AgnesJohn.Services;

namespace EventRegistrationAPI_AgnesJohn.Controllers
{
    // Handles HTTP requests for campus events.
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/events
        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> GetAll()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        // GET: api/events/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            var campusEvent = await _eventService.GetEventByIdAsync(id);

            if (campusEvent == null)
            {
                return NotFound();
            }

            return Ok(campusEvent);
        }

        // POST: api/events
        [HttpPost]
        public async Task<ActionResult<EventDto>> Create(
            CreateEventDto dto)
        {
            var campusEvent = await _eventService.CreateEventAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = campusEvent.EventId },
                campusEvent);
        }
    }
}