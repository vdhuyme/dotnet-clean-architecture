# Web.Api Layer

This layer serves as the entry point for the application, handling HTTP requests and responses.

## ✅ Do's

- Create API endpoints using minimal API syntax
- Handle HTTP-specific concerns (routing, status codes, etc.)
- Transform DTOs to/from Application layer commands/queries
- Configure API-specific middleware
- Handle API versioning
- Configure Swagger/OpenAPI documentation
- Implement basic request validation (size limits, content type, etc.)

## ❌ Don'ts

- Don't implement business logic
- Don't directly access the database
- Don't implement domain rules
- Don't handle domain events
- Don't implement authentication/authorization logic (only configure it)
- Don't create complex service classes

## 📁 Structure

```
Web.Api/
├── Endpoints/           # API endpoint definitions
│   ├── Todos/
│   └── Users/
├── Extensions/          # Extension methods for configuration
├── Infrastructure/      # API-specific infrastructure
├── Middleware/          # Custom middleware
└── Program.cs          # Application entry point
```

## 🔑 Key Concepts

1. **Minimal APIs**

   - Use .NET minimal API syntax for endpoints
   - Group related endpoints using MapGroup()
   - Keep endpoint handlers small and focused

2. **Request Pipeline**

   - Use middleware for cross-cutting concerns
   - Configure proper error handling
   - Set up proper CORS policies

3. **Documentation**

   - Use XML comments for API documentation
   - Configure Swagger/OpenAPI properly
   - Document response types and status codes

4. **Security**
   - Configure authentication middleware
   - Set up proper CORS policies
   - Implement rate limiting
   - Configure security headers

## 🔍 Examples

```csharp
// Good - Simple endpoint definition
app.MapPost("/todos", async (
    CreateTodoCommand command,
    ISender sender,
    CancellationToken cancellationToken) =>
{
    var result = await sender.Send(command, cancellationToken);
    return result.Match(
        todo => Results.Created($"/todos/{todo.Id}", todo),
        error => error.ToResponse());
});

// Bad - Business logic in endpoint
app.MapPost("/todos", async (
    CreateTodoRequest request,
    DbContext db) =>
{
    // Don't do this - business logic belongs in Application layer
    var todo = new Todo { ... };
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created(...);
});
```
