using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Features.Users;
using MechControl.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MechControl.Infrastructure.Persistence.Entities;

public class UserEntity : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                userId => userId.Value,
                value => StrongId.From<UserId>(value));

        builder.Property(p => p.Email)
            .HasConversion(
                email => email.Value,
                value => Email.New(value).Value);

        builder.Property(p => p.HashedPassword)
            .HasColumnName("hashed_password")
            .IsRequired();

        builder.Property(p => p.CreatedOnUtc)
            .HasColumnName("created_on_utc")
            .IsRequired();

        builder.Property(p => p.ModifiedOnUtc)
            .HasColumnName("modified_on_utc")
            .IsRequired();

        builder.Property(p => p.DeletedOnUtc)
            .HasColumnName("deleted_on_utc");


        builder.HasQueryFilter(p => p.DeletedOnUtc == null);
    }
}
