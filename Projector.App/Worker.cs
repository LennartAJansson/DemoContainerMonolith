namespace Projector.App;

using Common.Events;

using MediatR;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IEventService service;
    private readonly IMediator mediator;

    public Worker(ILogger<Worker> logger, IEventService service, IMediator mediator)
    {
        _logger = logger;
        this.service = service;
        this.mediator = mediator;
        this.service.OnCreatePersonEvent += Service_OnCreatePersonEvent;
    }

    private void Service_OnCreatePersonEvent(CloudNative.CloudEvents.CloudEvent command)
    {
        Task.Factory.StartNew(async () =>
        {
            bool result = await mediator.Send(command.Data as CreatePersonCommand);
        });
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
