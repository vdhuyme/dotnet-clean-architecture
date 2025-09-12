# Clean Architecture Solution

This solution follows Clean Architecture principles to build a maintainable and testable .NET application.

## 🏗️ Architecture Overview

The solution is divided into these main layers:

```
src/
├── Web.Api           # API Endpoints, Controllers, DTOs
├── Application       # Business Logic, Commands/Queries
├── Infrastructure   # External Concerns (DB, Auth, etc.)
├── Domain           # Business Entities and Rules
└── SharedKernel     # Shared Components and Interfaces
```

## 🚀 Key Features

- Clean Architecture implementation
- CQRS pattern with MediatR
- Domain-Driven Design (DDD) concepts
- JWT Authentication
- PostgreSQL with EF Core
- FluentValidation
- Domain Events

## 🛠️ Technologies

- .NET 8
- Entity Framework Core
- PostgreSQL
- MediatR
- FluentValidation
- JWT Authentication
- Docker support

## 🏃‍♂️ Getting Started

1. **Prerequisites**

   - .NET 8 SDK
   - Docker (for PostgreSQL)
   - Visual Studio 2022/Rider

2. **Setup Database**

   ```powershell
   docker-compose up -d
   ```

3. **Run Migrations**

   ```powershell
   dotnet ef database update --project src/Infrastructure --startup-project src/Web.Api
   ```

4. **Run the Application**
   ```powershell
   dotnet run --project src/Web.Api
   ```

## 📐 Architecture Decision Records

See individual README files in each layer for specific guidelines and rules:

- [Web.Api Layer](src/Web.Api/README.md)
- [Application Layer](src/Application/README.md)
- [Infrastructure Layer](src/Infrastructure/README.md)
- [Domain Layer](src/Domain/README.md)
- [SharedKernel](src/SharedKernel/README.md)

## 📝 Code Conventions

- **Naming**: Follow Microsoft's .NET naming conventions
- **Database**: Uses snake_case for column names
- **Commands/Queries**: Follow CQRS pattern with command/query separation
- **Validation**: Uses FluentValidation in Application layer
- **Error Handling**: Consistent error handling using Result pattern

## 🔒 Security

- JWT-based authentication
- Password hashing using modern algorithms
- Role-based authorization
- Input validation on all endpoints

## 📦 Project Structure Details

Each feature (e.g., Todos, Users) follows vertical slice architecture:

```
Feature/
├── Commands/          # Write operations
│   └── Create/
│       ├── Command.cs
│       ├── Handler.cs
│       └── Validator.cs
└── Queries/           # Read operations
    └── Get/
        ├── Query.cs
        ├── Handler.cs
        └── Validator.cs
```
