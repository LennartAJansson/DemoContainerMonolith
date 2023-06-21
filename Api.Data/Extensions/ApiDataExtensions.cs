namespace Microsoft.Extensions.DependencyInjection;

using Api.Data.Services;

public static class ApiDataExtensions
{
    public static IServiceCollection AddApiQueryServices(this IServiceCollection services)
    {
        services.AddTransient<IQueryService, QueryService>();

        return services;
    }
}

