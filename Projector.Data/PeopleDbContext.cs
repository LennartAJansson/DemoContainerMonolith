namespace Projector.Data;

using Microsoft.EntityFrameworkCore;

using Projector.Model;

public sealed class PeopleDbContext : DbContext
{
    public DbSet<Person> People => Set<Person>();
    public PeopleDbContext(DbContextOptions options): base(options)
    {
    }
}
