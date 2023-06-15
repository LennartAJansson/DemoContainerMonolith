namespace Api.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Api.Data;
using Api.Model;

using CloudNative.CloudEvents;

using Common.Events;

using MediatR;

public sealed class ApiMediator : 
    IRequestHandler<CreatePersonCommand, bool>,
    IRequestHandler<GetPeopleQuery, IEnumerable<PersonResponse>>,
    IRequestHandler<GetPersonQuery, PersonResponse>
{
    private readonly IEventService eventService;
    private readonly IQueryService queryService;

    public ApiMediator(IEventService eventService, IQueryService queryService)
    {
        this.eventService = eventService;
        this.queryService = queryService;
    }
    public Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var evt = new CloudEvent()
        {
            Type = "CreatePersonCommand",
            Data = request
        };


        eventService.PublishEvent(evt);

        return Task.FromResult(true);
    }

    public async Task<IEnumerable<PersonResponse>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        return await queryService.GetPeople();
    }

    public async Task<PersonResponse> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        return await queryService.GetPersonById(request.id);
    }
}
