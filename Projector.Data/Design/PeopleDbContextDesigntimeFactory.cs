namespace Projector.Data.Design;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Projector.Data.Context;

//TODO: From Package Manager Console execute:
//Add-Migration -Name your-migration-name -Context PeopleDbContext -Project Projector.Data -StartupProject Projector.Data
//Update-Database -Context PeopleDbContext -Project Projector.Data -StartupProject Projector.Data

public sealed class PeopleDbContextDesigntimeFactory : IDesignTimeDbContextFactory<PeopleDbContext>
{
    public PeopleDbContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<PeopleDbContext>()
            .Build();

        string? connectionString = configuration.GetConnectionString("PeopleDb");

        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        builder.UseSqlServer(connectionString);
        return new PeopleDbContext(builder.Options);
    }
}
