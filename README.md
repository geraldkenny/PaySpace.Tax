# PaySpace Tax Calculator

# Overview
This is a tax calculator application built with ASP.NET Core MVC latest and Entity Framework Core. The application calculates tax based on annual income and postal code, and stores the results in a SQL Server database.

## Architecture
The application follows a clean architecture:

- Presentation Layer: ASP.NET Core Web API
- Application Layer: Tax calculation services, repositories
- Domain Layer: Models and domain logic
- Infrastructure Layer: Data access (Entity Framework), repositories

## Prerequisites
Make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server/Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Git
- IDE preferably Visual Studio/Code

## Getting Started
- Clone the repository `git clone `
- Ensure your SQL Server is up and running.
- Update the connection string in `appsettings.development.json` to point to .MDF file attached in the `solution items` folder. For more information check [here](https://learn.microsoft.com/en-us/visualstudio/data-tools/add-new-connections?view=vs-2022)
- Run project
- The Project should be accessible at `https://localhost:7215;http://localhost:5064` by default.

## Additional Instructions
- Running Tests: To run unit tests, navigate to the test project (e.g., PaySpace.Tax.Application.Tests) and execute dotnet test.
- Troubleshooting: If you encounter issues, ensure that the prerequisites are correctly installed, and the connection string is accurate.
  
