namespace Api.Data.Services;

using Common.Contracts.Responses;

public interface IQueryService
{
    Task<IEnumerable<PersonResponse>> GetPeople();
    Task<PersonResponse> GetPersonById(int id);
}

