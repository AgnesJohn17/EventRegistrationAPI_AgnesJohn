
using EventRegistrationAPI_AgnesJohn.DTOs;

namespace EventRegistrationAPI_AgnesJohn.Services
{
    // Defines the available registration operations.
    public interface IRegistrationService
    {
        Task<List<RegistrationDto>?> GetRegistrationsAsync(int eventId);

        Task<RegistrationDto> RegisterAsync(
            int eventId, CreateRegistrationDto dto);

        Task<bool> DeleteRegistrationAsync(int id);
    }
}
