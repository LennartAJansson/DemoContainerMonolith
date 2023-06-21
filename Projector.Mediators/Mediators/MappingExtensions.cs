namespace Projector.Mediators.Mediators;

using Common.Contracts.Commands;
using Common.Contracts.Responses;

using Projector.Model;

public static class MappingExtensions
{
    public static Person ToPerson(this CreatePersonCommand request) => new()
    {
        Id = request.Id,
        Name = request.Name
    };

    public static PersonResponse ToPersonResponse(this Person person) => new(person.Id, person.Name);
}