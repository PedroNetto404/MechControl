using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Features.Customers;
using MechControl.Domain.Features.Customers.ValueObjects;
using MechControl.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MechControl.Infrastructure.Persistence.Entities;

public class CustomerEntity : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(c => c.Id);
        builder
            .Property(c => c.Id)
            .HasConversion(
                customerId => customerId.Value,
                value => StrongId.From<CustomerId>(value));

        builder
            .Property(c => c.Name)
            .HasConversion(
                name => name.Fullname,
                value => Name.New(value).Value)
            .IsRequired()
            .HasColumnName("full_name");

        builder.OwnsOne(c => c.Address, address =>
        {
            address.Property(a => a.Street)
                .HasColumnName("address_street")
                .IsRequired();

            address.Property(a => a.Number)
                .HasColumnName("address_number")
                .IsRequired();

            address.Property(a => a.Complement)
                .HasColumnName("address_complement");

            address.Property(a => a.Neighborhood)
                .HasColumnName("address_neighborhood")
                .IsRequired();

            address.Property(a => a.City)
                .HasColumnName("address_city")
                .IsRequired();

            address.Property(a => a.StateCode)
                .HasColumnName("address_state_code")
                .IsRequired();
        });

        builder
            .Property(c => c.Phone)
            .HasConversion(
                phone => phone.Value,
                value => Phone.New(value)
            )
            .IsRequired()
            .HasColumnName("phone");
        builder.HasIndex(c => c.Phone).IsUnique();

        builder
            .Property(c => c.Email)
            .HasConversion(
                email => email.Value,
                value => Email.New(value))
            .IsRequired()
            .HasColumnName("email");
        builder
            .HasIndex(c => c.Email)
            .IsUnique();

        builder.Property(c => c.CreatedOnUtc)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(c => c.ModifiedOnUtc)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(c => c.DeletedOnUtc)
            .HasColumnName("deleted_at");
        builder.HasQueryFilter(c => c.DeletedOnUtc == null);

        builder.Property<Cpf>("Cpf")
            .HasColumnName("cpf")
            .HasConversion(
                cpf => cpf.Value,
                value => Cpf.New(value));

        builder.Property<DateTime>("BirthDate")
            .HasColumnName("birth_date");

        builder.Property<Cnpj>("Cnpj")
            .HasColumnName("cnpj")
            .HasConversion(
                cnpj => cnpj.Value,
                value => Cnpj.New(value));

        builder.Property<bool>("IsMei")
            .HasColumnName("is_mei");

        builder.Property<string>("TradeName")
            .HasColumnName("trade_name");

        builder.Property<string>("CompanyName")
            .HasColumnName("company_name");

        builder.HasDiscriminator<string>("customer_type")
            .HasValue<IndividualCustomer>("individual")
            .HasValue<CorporateCustomer>("corporate");
    }
}