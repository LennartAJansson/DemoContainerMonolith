namespace Projector.Mediators.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Common.Contracts.Commands;
using Common.Contracts.Responses;
using Common.Events;

using MediatR;

using Projector.Data.Services;
using Projector.Model;

public class ProjectorMediator :
    IRequestHandler<CreatePersonCommand, PersonResponse>
{
    private readonly IPeopleService service;

    public ProjectorMediator(IPeopleService service)
    {
        this.service = service;
    }

    public async Task<PersonResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        Person person = request.ToPerson();
        
        person = await service.CreateAsync(person);

        return person.ToPersonResponse();
    }
}
