namespace Microsoft.Extensions.DependencyInjection;

using Projector.App;
using Projector.Mediators;

public static class ProjectorExtensions
{
    public static IServiceCollection AddProjector(this IServiceCollection services, string connectionString)
    {
        services.AddPeopleDb(connectionString);
        services.AddEvents();
        _ = services.AddHostedService<Worker>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProjectorMediator).Assembly));
        return services;
    }
}
