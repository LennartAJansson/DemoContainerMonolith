namespace Common.Events.Services;

using CloudNative.CloudEvents;

using Common.Events.Events;

public interface IEventService
{
    event CreatePersonDelegate OnCreatePersonEvent;

    Task PublishEvent(CloudEvent command);
}
