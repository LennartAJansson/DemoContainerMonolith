namespace Api.Data;

using System.Data.SqlClient;

using Api.Model;

using Dapper;

using Microsoft.Extensions.Configuration;

public sealed class QueryService : IQueryService
{
    private readonly IConfiguration configuration;

    public QueryService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public async Task<IEnumerable<PersonResponse>> GetPeople()
    {
        var sql = "SELECT * FROM People";
        using (var connection = new SqlConnection(configuration.GetConnectionString("PeopleDb")))
        {
            connection.Open();
            var result = await connection.QueryAsync<PersonResponse>(sql);
            return result;
        }
    }

    public async Task<PersonResponse> GetPersonById(int id)
    {
        var sql = "SELECT * FROM People WHERE Id = @Id";
        using (var connection = new SqlConnection(configuration.GetConnectionString("PeopleDb")))
        {
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<PersonResponse>(sql, new { Id = id });
            return result;
        }
    }
}

