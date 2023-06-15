namespace Api.Data;

using Api.Model;

public interface IQueryService
{
    Task<IEnumerable<PersonResponse>> GetPeople();
    Task<PersonResponse> GetPersonById(int id);
}

