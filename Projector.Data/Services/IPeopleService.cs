namespace Projector.Data.Services;

using Projector.Model;

public interface IPeopleService
{
    Task<Person> CreateAsync(Person person);
    Task<IEnumerable<Person>> GetPeople();
    Task<Person?> GetPersonById(Guid id);

}