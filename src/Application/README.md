# Application Layer

This layer contains application business logic and orchestrates the domain objects to perform tasks.

## ✅ Do's

- Implement commands and queries (CQRS)
- Write validation logic using FluentValidation
- Orchestrate domain objects
- Handle domain events
- Define interfaces for external dependencies
- Implement business workflows
- Use Result pattern for error handling

## ❌ Don'ts

- Don't implement infrastructure concerns
- Don't reference infrastructure packages
- Don't implement domain rules (belong in Domain layer)
- Don't directly interact with external services
- Don't handle HTTP concerns
- Don't implement data access logic

## 📁 Structure

```
Application/
├── Abstractions/        # Interfaces for external dependencies
├── Behaviors/          # Cross-cutting behaviors (validation, logging)
└── Features/          # Feature-specific commands and queries
    ├── Todos/
    │   ├── Create/
    │   ├── Update/
    │   └── Delete/
    └── Users/
        ├── Register/
        └── Login/
```

## 🔑 Key Concepts

1. **CQRS Pattern**

   - Commands: Write operations that modify state
   - Queries: Read operations that return data
   - Separate command and query models

2. **Validation**

   - Use FluentValidation for input validation
   - Implement validation as a behavior
   - Return descriptive validation errors

3. **Error Handling**
   - Use Result pattern consistently
   - Define clear error types
   - Handle domain errors appropriately

## 🔍 Examples

```csharp
// Good - Command handler with proper separation
public class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand, Result<TodoDto>>
{
    private readonly IRepository<Todo> _repository;

    public async Task<Result<TodoDto>> Handle(CreateTodoCommand command)
    {
        var todo = Todo.Create(command.Title, command.Description);
        await _repository.AddAsync(todo);
        return Result.Success(todo.ToDto());
    }
}

// Good - Validator
public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Description)
            .MaximumLength(1000);
    }
}

// Bad - Infrastructure concerns in handler
public class CreateTodoCommandHandler
{
    private readonly DbContext _db; // Don't reference EF directly

    public async Task Handle(CreateTodoCommand command)
    {
        // Don't do direct database access
        _db.Todos.Add(new TodoEntity { ... });
        await _db.SaveChangesAsync();
    }
}
```
