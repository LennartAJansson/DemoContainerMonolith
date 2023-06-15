namespace Common.Events;

using CloudNative.CloudEvents;

public delegate void CreatePersonDelegate(CloudEvent command);

public class EventService : IEventService
{
    public event CreatePersonDelegate OnCreatePersonEvent;
    public Task PublishEvent(CloudEvent command)
    {
        OnCreatePersonEvent?.Invoke(command);
        return Task.CompletedTask;
    }
}
