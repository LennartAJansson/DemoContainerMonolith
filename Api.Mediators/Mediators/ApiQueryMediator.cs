namespace Api.Mediators.Mediators;

using System.Threading;
using System.Threading.Tasks;
using Api.Data.Services;

using Common.Contracts.Queries;
using Common.Contracts.Responses;

using MediatR;

using Microsoft.Extensions.Logging;

public sealed class ApiQueryMediator :
    IRequestHandler<GetPeopleQuery, IEnumerable<PersonResponse>>,
    IRequestHandler<GetPersonQuery, PersonResponse>
{
    private readonly ILogger<ApiQueryMediator> logger;
    private readonly IQueryService queryService;

    public ApiQueryMediator(ILogger<ApiQueryMediator> logger, IQueryService queryService)
    {
        this.logger = logger;
        this.queryService = queryService;
    }

    public async Task<IEnumerable<PersonResponse>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetPeople");

        return await queryService.GetPeople();
    }

    public async Task<PersonResponse> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetPersonById {id}", request);

        return await queryService.GetPersonById(request.Id);
    }
}
