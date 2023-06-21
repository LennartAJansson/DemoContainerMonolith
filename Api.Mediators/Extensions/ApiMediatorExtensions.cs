namespace Microsoft.Extensions.DependencyInjection;

public static class ApiMediatorExtensions
{
    public static IServiceCollection AddApiMediators(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApiMediatorExtensions).Assembly));
        
        return services;
    }
}