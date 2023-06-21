namespace Common.Events.Services;

using CloudNative.CloudEvents;

using Common.Events.Events;

using Microsoft.Extensions.Logging;

public class EventService : IEventService
{
    private readonly ILogger<EventService> logger;

    public event CreatePersonDelegate? OnCreatePersonEvent = default;

    public EventService(ILogger<EventService> logger)
    {
        this.logger = logger;
    }

    public Task PublishEvent(CloudEvent command)
    {
        logger.LogInformation("Invoking");
        OnCreatePersonEvent?.Invoke(command);

        return Task.CompletedTask;
    }
}
