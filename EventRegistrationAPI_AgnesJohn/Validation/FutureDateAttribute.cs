
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationAPI_AgnesJohn.Validation
{
    // Ensures that new events have a future date.
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime eventDate)
            {
                return eventDate > DateTime.Now;
            }

            return false;
        }
    }
}
