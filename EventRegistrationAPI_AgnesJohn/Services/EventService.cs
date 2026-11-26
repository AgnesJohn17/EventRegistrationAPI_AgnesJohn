
using EventRegistrationAPI_AgnesJohn.Data;
using EventRegistrationAPI_AgnesJohn.DTOs;
using EventRegistrationAPI_AgnesJohn.Models;
using Microsoft.EntityFrameworkCore;

namespace EventRegistrationAPI_AgnesJohn.Services
{
    // Handles database operations for campus events.
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }

        // Returns all events sorted by date.
        public async Task<List<EventDto>> GetAllEventsAsync()
        {
            return await _context.Events
                .OrderBy(e => e.EventDate)
                .Select(e => new EventDto
                {
                    EventId = e.EventId,
                    Title = e.Title,
                    Location = e.Location,
                    EventDate = e.EventDate,
                    Capacity = e.Capacity,
                    RegisteredCount = e.Registrations.Count,
                    SpotsLeft = e.Capacity - e.Registrations.Count
                })
                .ToListAsync();
        }

        // Returns an event by its ID.
        public async Task<EventDto?> GetEventByIdAsync(int id)
        {
            return await _context.Events
                .Where(e => e.EventId == id)
                .Select(e => new EventDto
                {
                    EventId = e.EventId,
                    Title = e.Title,
                    Location = e.Location,
                    EventDate = e.EventDate,
                    Capacity = e.Capacity,
                    RegisteredCount = e.Registrations.Count,
                    SpotsLeft = e.Capacity - e.Registrations.Count
                })
                .FirstOrDefaultAsync();
        }

        // Creates an event and returns its DTO.
        public async Task<EventDto> CreateEventAsync(CreateEventDto dto)
        {
            var campusEvent = new Event
            {
                Title = dto.Title,
                Location = dto.Location,
                EventDate = dto.EventDate,
                Capacity = dto.Capacity
            };

            _context.Events.Add(campusEvent);
            await _context.SaveChangesAsync();

            // New events have no registrations.
            return new EventDto
            {
                EventId = campusEvent.EventId,
                Title = campusEvent.Title,
                Location = campusEvent.Location,
                EventDate = campusEvent.EventDate,
                Capacity = campusEvent.Capacity,
                RegisteredCount = 0,
                SpotsLeft = campusEvent.Capacity
            };
        }
    }
}
