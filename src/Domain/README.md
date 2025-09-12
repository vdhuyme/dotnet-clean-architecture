# Domain Layer

This layer contains enterprise business rules and entities. It's the core of the application and should be independent of other layers.

## ✅ Do's

- Define entities and value objects
- Implement domain logic and rules
- Define domain events
- Create domain exceptions
- Define domain interfaces
- Implement business invariants
- Define domain services if needed

## ❌ Don'ts

- Don't reference other layers
- Don't implement infrastructure concerns
- Don't handle persistence
- Don't implement UI logic
- Don't depend on external packages (except essential ones)
- Don't handle HTTP or API concerns

## 📁 Structure

```
Domain/
├── Entities/          # Domain entities
├── ValueObjects/      # Value objects
├── Events/           # Domain events
├── Exceptions/       # Domain-specific exceptions
└── Services/         # Domain services
```

## 🔑 Key Concepts

1. **Rich Domain Model**

   - Entities contain behavior
   - Enforce invariants
   - Use value objects
   - Raise domain events

2. **Domain Events**

   - Define events for significant changes
   - Keep events immutable
   - Include relevant event data

3. **Business Rules**
   - Implement in entities
   - Use guard clauses
   - Throw domain exceptions
   - Maintain invariants

## 🔍 Examples

```csharp
// Good - Rich domain entity
public class Todo : Entity
{
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }

    private Todo(string title)
    {
        Title = Guard.Against.NullOrEmpty(title);
        IsCompleted = false;
    }

    public static Todo Create(string title)
    {
        var todo = new Todo(title);
        todo.AddDomainEvent(new TodoCreatedDomainEvent(todo.Id));
        return todo;
    }

    public void Complete()
    {
        if (IsCompleted)
            throw new TodoAlreadyCompletedException(Id);

        IsCompleted = true;
        AddDomainEvent(new TodoCompletedDomainEvent(Id));
    }
}

// Good - Value Object
public class Priority : ValueObject
{
    public string Value { get; }

    private Priority(string value)
    {
        Value = value;
    }

    public static Priority Create(string value)
    {
        if (!IsValid(value))
            throw new InvalidPriorityException(value);

        return new Priority(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

// Bad - Infrastructure concerns in domain
public class Todo
{
    private readonly DbContext _context; // Don't do this

    public async Task Save()
    {
        // Don't handle persistence in domain
        await _context.SaveChangesAsync();
    }
}
```
