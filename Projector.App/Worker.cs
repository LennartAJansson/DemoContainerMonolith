namespace Projector.App;

using CloudNative.CloudEvents;

using Common.Contracts.Commands;
using Common.Events.Services;
using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> logger;
    private readonly IEventService service;
    private readonly IServiceProvider provider;

    public Worker(ILogger<Worker> logger, IEventService service, IServiceProvider provider)
    {
        this.logger = logger;
        this.service = service;
        this.provider = provider;
        this.service.OnCreatePersonEvent += Service_OnCreatePersonEvent;
    }

    private void Service_OnCreatePersonEvent(CloudEvent command)
    {
        if (command.Data is not null && command.Data is CreatePersonCommand)
        {
            Task.Factory.StartNew(async () =>
            {
                logger.LogInformation("Sending data to projectors mediator");
                using var scope = provider.CreateAsyncScope();
                await scope.ServiceProvider.GetRequiredService<IMediator>().Send(command.Data);
            });
        }
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
