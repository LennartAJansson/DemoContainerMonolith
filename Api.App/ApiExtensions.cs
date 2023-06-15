namespace Microsoft.Extensions.DependencyInjection;

using Api.Data;
using Api.Mediators;

using Common.Events;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

public static class ApiExtensions
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddEvents();
        services.AddTransient<IQueryService, QueryService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApiMediator).Assembly));

        return services;
    }

    public static IEndpointRouteBuilder UseApi(this IEndpointRouteBuilder builder)
    {
        RouteGroupBuilder group = builder.MapGroup("/people").WithTags("People");
        _ = group.MapPost("/CreatePerson", async ([FromBody] CreatePersonCommand request, IMediator mediator) => 
        {
            return await mediator.Send(request);
        }).WithName("CreatePerson").WithOpenApi();

        _ = group.MapPost("/GetPerson", async (int id, IMediator mediator) =>
        {
            return await mediator.Send(new GetPersonQuery(id));
        }).WithName("GetPerson").WithOpenApi();

        _ = group.MapPost("/GetPeople", async (IMediator mediator) =>
        {
            return await mediator.Send(new GetPeopleQuery());
        }).WithName("GetPeople").WithOpenApi();

        return builder;
    }
}
