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

    public string HashedPassword { get; set; }

    public DateTime CreatedOnUtc { get; } = DateTime.UtcNow;

    public DateTime ModifiedOnUtc { get; private set; } = DateTime.UtcNow;

    public DateTime? DeletedOnUtc { get; private set; }


    private User(Email email, string hashedPassword)
    {
        Email = email;
        HashedPassword = hashedPassword;
    }

    public static User New(
        Email email,
        string hashedPassword)
    {
        var user = new User(email, hashedPassword);
        user.RaiseDomainEvent(new UserCreated(user.Id));

        return user;
    }

#pragma warning disable CS0628 // New protected member declared in sealed type


    protected User() { }
#pragma warning restore CS0628 // New protected member declared in sealed type

}
