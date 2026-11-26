
using EventRegistrationAPI_AgnesJohn.Data;
using EventRegistrationAPI_AgnesJohn.DTOs;
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

        // Returns all events sorted by event date.
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

        // Returns a single event using its ID.
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
    }
}
