namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using Projector.Data.Context;
using Projector.Data.Services;

public static class DbExtensions
{
    public static IServiceCollection AddPeopleDb(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PeopleDbContext>(options => options.UseSqlServer(connectionString));
        services.AddTransient<IPeopleService,PeopleService>();
        
        return services;
    }

    public static IHost UpdatePeopleDb(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<PeopleDbContext>().EnsureDb();

        return host;
    }
}
