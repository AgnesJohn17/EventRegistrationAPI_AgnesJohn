
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationAPI_AgnesJohn.Models
{
    // Represents a student's registration for an event.
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }

        public int EventId { get; set; }

        [Required]
        public string StudentName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public DateTime RegisteredOn { get; set; }

        public Event Event { get; set; } = null!;
    }
}
