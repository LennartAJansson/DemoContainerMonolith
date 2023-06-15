namespace Common.Events;

using Api.Model;

using MediatR;

public record CreatePersonCommand(string Name): IRequest<bool>;
public record GetPersonQuery(int id): IRequest<PersonResponse>;
public record GetPeopleQuery(): IRequest<IEnumerable<PersonResponse>>;
