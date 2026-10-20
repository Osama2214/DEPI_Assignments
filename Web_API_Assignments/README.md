# Web API Assignments - Library System

This project is a simple ASP.NET Core Web API for managing a library system.
It uses Entity Framework Core Code First, DTOs, AutoMapper, and asynchronous programming.
The same project is updated with the new topics covered in each Web API session.

## Entities

- `Author`
- `Book`
- `Borrower`
- `Loan`

## Relationships

- One Author has many Books.
- Books and Borrowers have a many-to-many relationship through Loan.

## CRUD Endpoints

Each entity has the following endpoints:

- `GET` - Get all records.
- `GET /{id}` - Get one record.
- `POST` - Create a record.
- `PUT` - Update a record.
- `DELETE` - Delete a record.

Loan uses `BookId` and `BorrowerId` as a composite key.

Delete endpoints use soft delete. Deleted records stay in the database and are
hidden automatically by global query filters.

## Session Two Features

- Separate create, update, and response DTOs.
- AutoMapper for response mapping.
- Navigation data using `Include`.
- Read-only queries using `AsNoTracking`.
- Soft delete and global query filters.
- Entity configurations in separate classes.
- Automatic migrations when the application starts.
- Initial author data loaded from JSON.
- Swagger UI for testing the endpoints.

## Technologies

- ASP.NET Core Web API
- .NET 10
- Entity Framework Core 10
- SQL Server LocalDB
- AutoMapper
- Swagger
- DTOs
- Async/Await

## Project Structure

```text
LibraryApi/
├── Controllers/
├── Data/
│   ├── Configurations/
│   └── Seeding/
├── Dtos/
├── Extensions/
├── Helper/
├── Migrations/
└── Models/
```

## Database Diagrams

- [Class diagram](Diagrams/Class/Library-Class-Diagram.md)
- [SQL Server database diagram](Diagrams/Database/LibraryDb_Diagram_SSMS.png)

## Run the Project

```powershell
dotnet tool restore
dotnet run --project LibraryApi
```

The database is migrated and seeded automatically when the project starts.
Swagger UI is available at `/swagger` in the development environment.

The request examples are available in `LibraryApi/LibraryApi.http`.
