
using Microsoft.EntityFrameworkCore;
using EventRegistrationAPI_AgnesJohn.Models;

namespace EventRegistrationAPI_AgnesJohn.Data
{
    // Manages database access for events and registrations.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed four campus events for testing.
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 1,
                    Title = "Career Workshop",
                    Location = "Room A101",
                    EventDate = new DateTime(2027, 6, 15, 10, 0, 0),
                    Capacity = 30
                },
                new Event
                {
                    EventId = 2,
                    Title = "Coding Competition",
                    Location = "Computer Lab",
                    EventDate = new DateTime(2027, 7, 20, 11, 0, 0),
                    Capacity = 20
                },
                new Event
                {
                    EventId = 3,
                    Title = "Leadership Seminar",
                    Location = "Room B205",
                    EventDate = new DateTime(2027, 8, 10, 14, 0, 0),
                    Capacity = 2
                },
                new Event
                {
                    EventId = 4,
                    Title = "Campus Orientation",
                    Location = "Main Hall",
                    EventDate = new DateTime(2026, 9, 5, 9, 0, 0),
                    Capacity = 50
                }
            );

            // Seed two registrations to make Event 3 full.
            modelBuilder.Entity<Registration>().HasData(
                new Registration
                {
                    RegistrationId = 1,
                    EventId = 3,
                    StudentName = "Alex Smith",
                    Email = "alex@example.com",
                    RegisteredOn = new DateTime(2026, 11, 20)
                },
                new Registration
                {
                    RegistrationId = 2,
                    EventId = 3,
                    StudentName = "Sarah Brown",
                    Email = "sarah@example.com",
                    RegisteredOn = new DateTime(2026, 11, 21)
                }
            );
        }
    }
}
