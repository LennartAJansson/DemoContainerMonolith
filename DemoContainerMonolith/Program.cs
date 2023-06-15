WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApi()
    .AddProjector(builder.Configuration.GetConnectionString("PeopleDb")
        ?? throw new ArgumentException("No connectionstring"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseApi();

app.Run();
