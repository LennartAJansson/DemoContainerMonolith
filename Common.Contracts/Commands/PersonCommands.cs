namespace Common.Contracts.Commands;

using Common.Contracts.Responses;

using MediatR;

public record AddPersonCommand(string Name) : IRequest<PersonResponse>;
public record CreatePersonCommand(Guid Id, string Name) : IRequest<PersonResponse>;
