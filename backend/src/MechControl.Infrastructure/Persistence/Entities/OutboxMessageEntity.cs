using MechControl.Infrastructure.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MechControl.Infrastructure.Persistence.Entities;

internal sealed class OutboxMessageEntity : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable("outbox_messages");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(m => m.EventData)
            .HasColumnName("event_data")
            .HasColumnType("jsonb")
            .IsRequired();

        builder.Property(m => m.EventyTypeName)
            .HasColumnName("event_type_name")
            .IsRequired();

        builder.Property(m => m.OccurredOnUtc)
            .HasColumnName("occurred_on_utc")
            .IsRequired();        
    
        builder.Property(m => m.ProcessedOnUtc)
            .HasColumnName("processed_date_utc");
    }
}