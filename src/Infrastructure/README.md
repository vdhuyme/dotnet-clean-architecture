# Infrastructure Layer

This layer implements interfaces defined in the Application layer and handles all external concerns.

## ✅ Do's

- Implement data access using EF Core
- Implement authentication/authorization
- Handle external service integration
- Implement caching mechanisms
- Handle file system operations
- Implement email services
- Configure logging
- Implement database migrations

## ❌ Don'ts

- Don't implement business logic
- Don't implement domain rules
- Don't expose domain objects directly
- Don't handle HTTP concerns
- Don't implement validation logic
- Don't create business workflows

## 📁 Structure

```
Infrastructure/
├── Authentication/     # Authentication implementation
├── Authorization/      # Authorization handlers
├── Database/          # EF Core context and configurations
│   └── Migrations/
├── DomainEvents/      # Event dispatching
├── Email/             # Email service implementation
├── Cache/             # Caching implementation
└── Persistence/       # Repository implementations
```

## 🔑 Key Concepts

1. **Persistence**

   - Implement Repository pattern
   - Handle database configurations
   - Manage database migrations
   - Configure entity mappings

2. **Authentication/Authorization**

   - Implement JWT token generation
   - Handle password hashing
   - Implement authorization policies
   - Manage user sessions

3. **External Services**
   - Implement HTTP clients
   - Handle retry policies
   - Implement circuit breakers
   - Handle external API responses

## 🔍 Examples

```csharp
// Good - Repository implementation
public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;

    public async Task<Todo> GetByIdAsync(Guid id)
    {
        return await _context.Todos
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}

// Good - Entity configuration
public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("todos");

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();
    }
}

// Bad - Business logic in repository
public class TodoRepository
{
    public async Task<Todo> CreateTodoAsync(string title)
    {
        // Don't do business logic here
        if (string.IsNullOrEmpty(title))
            throw new ArgumentException();

        var todo = new Todo { Title = title };
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }
}
```
