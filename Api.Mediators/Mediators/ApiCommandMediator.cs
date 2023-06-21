namespace Api.Mediators.Mediators;

using System.Threading;
using System.Threading.Tasks;

using CloudNative.CloudEvents;

using Common.Contracts.Commands;
using Common.Contracts.Responses;
using Common.Events;
using Common.Events.Services;
using MediatR;

using Microsoft.Extensions.Logging;

public sealed class ApiCommandMediator :
    IRequestHandler<AddPersonCommand, PersonResponse>
{
    private readonly ILogger<ApiCommandMediator> logger;
    private readonly IEventService eventService;

    public ApiCommandMediator(ILogger<ApiCommandMediator> logger, IEventService eventService)
    {
        this.logger = logger;
        this.eventService = eventService;
    }
    public async Task<PersonResponse> Handle(AddPersonCommand request, CancellationToken cancellationToken)
    {
        var personCommand = request.ToCreatePersonCommand();

        var evt = new CloudEvent()
        {
            Type = "CreatePersonCommand",
            Data = personCommand
        };

        logger.LogInformation("CreatePersonCommand {person}", personCommand);

        await eventService.PublishEvent(evt);

        return personCommand.ToPersonResponse();
    }
}
