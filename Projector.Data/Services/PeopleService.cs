﻿namespace Projector.Data.Services;

using Projector.Data.Context;
using Projector.Model;

public sealed class PeopleService : IPeopleService
{
    private readonly PeopleDbContext context;

    public PeopleService(PeopleDbContext context)
    {
        this.context = context;
    }
    public async Task<Person> CreateAsync(Person person)
    {
        context.Add(person);
        await context.SaveChangesAsync();

        return person;
    }

    public Task<IEnumerable<Person>> GetPeople() => Task.FromResult(context.People.AsEnumerable());

    public Task<Person?> GetPersonById(Guid id)
    {
        return Task.FromResult(context.People.FirstOrDefault(p => p.Id.Equals(id)));
    }
}
