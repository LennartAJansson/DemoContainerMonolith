IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context,services) =>
    {
        _ = services.AddProjector(context.Configuration.GetConnectionString("PeopleDb")
            ??throw new ArgumentException("No connectionstring"));
    })
    .Build();

host.Run();
