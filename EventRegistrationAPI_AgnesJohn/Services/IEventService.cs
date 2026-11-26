
using EventRegistrationAPI_AgnesJohn.DTOs;

namespace EventRegistrationAPI_AgnesJohn.Services
{
    // Defines the available event operations.
    public interface IEventService
    {
        Task<List<EventDto>> GetAllEventsAsync();

        Task<EventDto?> GetEventByIdAsync(int id);
    }
}
