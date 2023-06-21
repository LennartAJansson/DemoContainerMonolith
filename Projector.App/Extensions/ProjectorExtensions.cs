namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;

using Projector.App;

public static class ProjectorExtensions
{
    public static IServiceCollection AddProjector(this IServiceCollection services, string connectionString)
    {
        services.AddDomainEvents();
        services.AddProjectorMediators();
        services.AddPeopleDb(connectionString);
        services.AddHostedService<Worker>();
        
        return services;
    }

    public static IHost UseProjectorDb(this IHost host)
    {
        host.UpdatePeopleDb();

        return host;
    }
}
