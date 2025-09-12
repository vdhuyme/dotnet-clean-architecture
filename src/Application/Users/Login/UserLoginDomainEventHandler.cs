using Domain.Users;
using SharedKernel;

namespace Application.Users.Login;

internal sealed class UserLoginDomainEventHandler : IDomainEventHandler<UserLoginDomainEvent>
{
    public Task Handle(UserLoginDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
