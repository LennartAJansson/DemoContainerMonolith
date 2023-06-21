namespace Api.Mediators.Mediators;

using Common.Contracts.Commands;
using Common.Contracts.Responses;
public static class MappingExtensions
{
    public static CreatePersonCommand ToCreatePersonCommand(this AddPersonCommand request)
    {
        return new CreatePersonCommand(Guid.NewGuid(), request.Name);
    }

    public static PersonResponse ToPersonResponse(this CreatePersonCommand personCommand)
    {
        return new PersonResponse(personCommand.Id, personCommand.Name);
    }
}