namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using Projector.Data;

public static class DbExtensions
{
    public static IServiceCollection AddPeopleDb(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PeopleDbContext>(options => options.UseSqlServer(connectionString));
        services.AddTransient<IPeopleService,PeopleService>();
        
        return services;
    }
}
