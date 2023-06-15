namespace Projector.Data;

using Projector.Model;

public interface IPeopleService
{
    Task<Person> CreateAsync(Person person);
    Task<IEnumerable<Person>> GetPeople();
    Task<Person?> GetPersonById(int id);

}