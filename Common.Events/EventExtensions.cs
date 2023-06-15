namespace Microsoft.Extensions.DependencyInjection;

using Common.Events;
public static class EventExtensions
{

    public static IServiceCollection AddEvents(this IServiceCollection services)
    {
        services.AddSingleton<IEventService, EventService>();
        return services;
    }
}