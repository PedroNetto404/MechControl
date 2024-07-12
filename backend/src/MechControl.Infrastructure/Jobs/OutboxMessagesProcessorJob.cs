using System.Text.Json;
using Hangfire.Annotations;
using Hangfire.Server;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Primitives.Result;
using MechControl.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MechControl.Infrastructure.Jobs;

internal sealed class OutboxMessagesProcessorJob(
    MechControlContext context,
    ISender sender,
    ILogger<OutboxMessagesProcessorJob> logger
) 
{
    private readonly MechControlContext _context = context;
    private readonly ISender _sender = sender;
    private readonly ILogger<OutboxMessagesProcessorJob> _logger = logger;

    public async Task ExecuteAsync([NotNull] BackgroundProcessContext _)
    {
        var messages = await _context.OutboxMessages.ToListAsync();

        foreach (var message in messages)
        {
            var eventInstanceType = 
                typeof(IDomainEvent)
                    .Assembly
                    .DefinedTypes
                    .FirstOrDefault(t => t.Name == message.EventyTypeName);
            if(eventInstanceType is null)
            {
                _logger.LogError(
                    "Failed to find event type {EventType}",
                    message.EventyTypeName);

                continue;
            }

            var domainEvent = JsonSerializer.Deserialize(
                message.EventData,
                eventInstanceType);
            if(domainEvent is null)
            {
                _logger.LogError(
                    "Failed to deserialize event of type {EventType}/n{EventData}",
                    eventInstanceType,
                    message.EventData);

                continue;
            }

            if (await _sender.Send(domainEvent) is not Result result)
            {
                _logger.LogError(
                    "Failed to send event of type {EventType}\n{EventData}",
                    eventInstanceType,
                    message.EventData);

                continue;
            }

            message.ProcessedOnUtc = DateTime.UtcNow;
            _context.OutboxMessages.Update(message);
            await _context.SaveChangesAsync();
        }
    }
}