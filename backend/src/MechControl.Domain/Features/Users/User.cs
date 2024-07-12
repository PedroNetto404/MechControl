using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Features.Users.Events;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Users;

public sealed class UserId : StrongId
{
    private UserId(Guid value) : base(value)
    {
    }
}

public sealed class User : AggregateRoot<UserId>
{
    public Email Email { get; private set; }

    public string IdentityId { get; private set; }

    private User(
        Email email,
        string identityId)
    {
        Email = email;
        IdentityId = identityId;
    }

    public static User New(
        Email email,
        string identityId)
    {
        var user = new User(email, identityId);
        user.RaiseDomainEvent(new UserCreated(user.Id));

        return user;
    }

#pragma warning disable CS0628 // New protected member declared in sealed type

    protected User() { }
#pragma warning restore CS0628 // New protected member declared in sealed type

}