using SharedKernel;

namespace Domain.Users;

public sealed record UserLoginDomainEvent(Guid UserId) : IDomainEvent;
