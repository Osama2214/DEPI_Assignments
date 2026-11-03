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

## Session Three Features

- Generic Repository for CRUD operations, including composite keys.
- Author Repository with name search and pagination.
- Author Service for DTO mapping and operation results.
- Result Pattern using `Result` and `GenericResult<T>`.
- `PaginatedList<T>` with page metadata and a maximum page size of 20.
- Scoped repository and service registration through dependency injection.

Authors now use the Controller → Service → Repository flow. Books, Borrowers,
and Loans keep their existing Session Two endpoints.

`GET /api/authors?pageNumber=1&pageSize=10&searchTerm=Naguib` returns a
result whose `value` contains `data`, `pageNumber`, `pageSize`, `totalRecords`,
and `totalPages`. Author read and create responses use `value` for the DTO;
successful updates and deletes still return `204 No Content`.

## Session Four Features

- Exception middleware returns `500` Problem Details with a trace ID.
- Exception details are shown only in Development.
- Request timing middleware logs the method, path, status, and elapsed time.
- Request ID middleware adds the `X-Request-Id` response header.
- Rate limiting allows 10 requests per 10-second window for the application instance.
  Additional requests return `429` with a `Retry-After` header.
- EF Core interceptors set UTC creation and modification dates and convert
  deletes into soft deletes for both synchronous and asynchronous saves.

## Session Five Features

- MVC action logging filter records action start, completion, and unhandled failures.
- Async action timing filter records elapsed time, including failed actions.
- Exception filter returns Problem Details for unhandled Authors action exceptions.
- Filters are scoped services applied to Authors through `ServiceFilter`.
- The exception middleware still handles failures outside the filtered MVC actions.

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
│   ├── Interceptors/
│   └── Seeding/
├── Dtos/
├── Errors/
├── Extensions/
├── Filters/
├── Helper/
├── Migrations/
├── Middlewares/
├── Models/
├── Repositories/
├── Results/
└── Services/
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
