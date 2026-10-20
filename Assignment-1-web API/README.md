# Library System Web API

This project is a simple ASP.NET Core Web API for managing a library system.
It uses Entity Framework Core Code First, DTOs, and asynchronous programming.

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

## Technologies

- ASP.NET Core Web API
- .NET 10
- Entity Framework Core 10
- SQL Server LocalDB
- DTOs
- Async/Await

## Project Structure

```text
LibraryApi/
├── Controllers/
├── Data/
├── Dtos/
├── Migrations/
└── Models/
```

## Database Diagrams

- [Class diagram](Diagrams/Class/Library-Class-Diagram.md)
- [SQL Server database diagram](Diagrams/Database/LibraryDb_Diagram_SSMS.png)

## Run the Project

```powershell
dotnet tool restore
dotnet ef database update --project LibraryApi
dotnet run --project LibraryApi
```

The request examples are available in `LibraryApi/LibraryApi.http`.
