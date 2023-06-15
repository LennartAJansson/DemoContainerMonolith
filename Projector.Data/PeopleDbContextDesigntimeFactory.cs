namespace Projector.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

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
