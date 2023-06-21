namespace Common.Contracts.Queries;

using Common.Contracts.Responses;

using MediatR;

public record GetPersonQuery(int Id) : IRequest<PersonResponse>;
public record GetPeopleQuery() : IRequest<IEnumerable<PersonResponse>>;
