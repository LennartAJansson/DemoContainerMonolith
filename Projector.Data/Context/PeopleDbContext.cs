namespace Projector.Data.Context;

using System;

using Microsoft.EntityFrameworkCore;

using Projector.Model;

public sealed class PeopleDbContext : DbContext
{
    public DbSet<Person> People => Set<Person>();
    public PeopleDbContext(DbContextOptions options) : base(options)
    {
    }

    internal void EnsureDb()
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }
}
