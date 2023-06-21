namespace Microsoft.Extensions.DependencyInjection;

using Common.Events.Services;

public static class EventExtensions
{

    public static IServiceCollection AddDomainEvents(this IServiceCollection services)
    {
        services.AddSingleton<IEventService, EventService>();

        return services;
    }
}