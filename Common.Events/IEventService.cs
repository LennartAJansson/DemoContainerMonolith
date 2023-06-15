namespace Common.Events;

using CloudNative.CloudEvents;

public interface IEventService
{
    event CreatePersonDelegate OnCreatePersonEvent;

    Task PublishEvent(CloudEvent command);
}
