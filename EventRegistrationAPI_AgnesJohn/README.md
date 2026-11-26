
# Campus Event Registration API

PROG30000 - Enterprise Software Systems
Assignment 3 

## Project Overview

An ASP.NET Core Web API that allows users to view
campus events, create events, register for events
and cancel registrations.

## Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server LocalDB
- Swagger
- Git and GitHub

## How to Run

1. Open the solution in Visual Studio.
2. Restore the NuGet packages.
3. Run Update-Database in Package Manager Console.
4. Press F5 to launch Swagger.

## Business Rules

- The event must exist.
- Registration for past events is not allowed.
- Duplicate email registrations are not allowed.
- Registration is not allowed when an event is full.
- Cancelling a registration frees an available spot.

## Testing

All 12 required Swagger tests were completed
with the expected HTTP response codes.
