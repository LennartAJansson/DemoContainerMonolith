namespace Microsoft.Extensions.DependencyInjection;

public static class ProjectorMediatorExtensions
{
    public static IServiceCollection AddProjectorMediators(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProjectorMediatorExtensions).Assembly));

        return services;
    }
}
