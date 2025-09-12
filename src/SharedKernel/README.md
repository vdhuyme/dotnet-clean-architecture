# SharedKernel Layer

This layer contains common components, base classes, and interfaces that are shared across all layers of the application.

## ✅ Do's

- Define base entity classes
- Create shared interfaces
- Implement common value objects
- Define cross-cutting concerns
- Create utility classes
- Implement shared validation rules
- Define common exceptions

## ❌ Don'ts

- Don't implement business logic
- Don't reference other project layers
- Don't implement infrastructure concerns
- Don't add framework-specific code
- Don't include UI components
- Don't implement feature-specific code

## 📁 Structure

```
SharedKernel/
├── BaseEntities/      # Base entity classes
├── Interfaces/        # Shared interfaces
├── ValueObjects/      # Common value objects
├── Exceptions/        # Base exceptions
└── Extensions/        # Shared extensions
```

## 🔑 Key Concepts

1. **Base Classes**

   - Entity base class
   - Value object base class
   - Common interfaces
   - Abstract validators

2. **Common Patterns**

   - Result pattern
   - Error handling
   - Domain events
   - Guard clauses

3. **Cross-Cutting Concerns**
   - Logging interfaces
   - Time providers
   - Common validation rules
   - Shared constants

## 🔍 Examples

```csharp
// Good - Base entity class
public abstract class Entity
{
    public Guid Id { get; protected set; }
    private readonly List<IDomainEvent> _domainEvents = new();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IReadOnlyCollection<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }
}

// Good - Result pattern
public class Result<T>
{
    public T Value { get; }
    public bool IsSuccess { get; }
    public Error Error { get; }

    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
    }

    private Result(Error error)
    {
        Error = error;
        IsSuccess = false;
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(Error error) => new(error);
}

// Bad - Business logic in shared kernel
public abstract class Entity
{
    public void ProcessBusinessRule()  // Don't do this
    {
        // Business logic should be in domain layer
    }
}
```
