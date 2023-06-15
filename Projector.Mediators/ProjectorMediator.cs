namespace Projector.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Common.Events;

using MediatR;

using Projector.Data;
using Projector.Model;

public class ProjectorMediator :
    IRequestHandler<CreatePersonCommand, bool>
{
    private readonly IPeopleService service;

    public ProjectorMediator(IPeopleService service)
    {
        this.service = service;
    }
    public Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        Person person = request.ToPerson();
        return Task.FromResult(true);
    }
}


public static class ModelExtensions
{
    public static Person ToPerson(this CreatePersonCommand request)
    {
        return new Person
        {
            Name = request.Name
        };
    }
}