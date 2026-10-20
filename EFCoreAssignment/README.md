# EF Core Assignment

This solution implements the three requirements as three separate ASP.NET Core Web API projects. Each project uses Entity Framework Core Code First with SQL Server and has its own models, `DbContext`, migration, database, class diagram, and SQL Server database diagram screenshot.

## Projects

| Project | Database | Main entities |
| --- | --- | --- |
| `ECommerceApi` | `ECommerceDb` | Category, Product, Customer, Order, OrderDetail |
| `LibraryApi` | `LibraryDb` | Author, Book, Borrower, Loan |
| `HealthCareApi` | `HealthCareDb` | Patient, Doctor, Appointment |

The current assignment focuses on the database design and EF Core Code First setup. API endpoints can be added later to one selected project during the Web API part of the course.

## Technologies

- ASP.NET Core Web API
- .NET 10
- Entity Framework Core 10
- SQL Server LocalDB
- Code First migrations

## Relationships

### E-Commerce

- One Category has many Products.
- One Customer has many Orders.
- Orders and Products have a many-to-many relationship through OrderDetail.

### Library

- One Author has many Books.
- Books and Borrowers have a many-to-many relationship through Loan.

### Health Care

- Patients and Doctors have a many-to-many relationship through Appointment.

## Class Diagrams

- [E-Commerce class diagram](Diagrams/Class/ECommerce-Class-Diagram.md)
- [Library class diagram](Diagrams/Class/Library-Class-Diagram.md)
- [Health Care class diagram](Diagrams/Class/HealthCare-Class-Diagram.md)

## SQL Server Database Diagram Screenshots

- [ECommerceDb diagram](Diagrams/Database/ECommerceDb_Diagram_SSMS.jpg)
- [LibraryDb diagram](Diagrams/Database/LibraryDb_Diagram_SSMS.jpg)
- [HealthCareDb diagram](Diagrams/Database/HealthCareDb_Diagram_SSMS.jpg)

## Navigation Property Article

- [LinkedIn article draft](LinkedInArticle-Navigation-Properties.md)

## Run the Solution

Restore and build all projects:

```powershell
dotnet restore EFCoreAssignment.sln
dotnet build EFCoreAssignment.sln
```

Create or update the three databases:

```powershell
dotnet tool restore
dotnet ef database update --project ECommerceApi
dotnet ef database update --project LibraryApi
dotnet ef database update --project HealthCareApi
```

Run any project, for example:

```powershell
dotnet run --project ECommerceApi
```

