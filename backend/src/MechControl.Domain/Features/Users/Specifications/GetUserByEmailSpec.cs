using Ardalis.Specification;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Users.Specifications;

public class GetUserByEmailSpec : Specification<User>
{
    public GetUserByEmailSpec(Email email) =>
         Query.Where(user => user.Email == email);
}