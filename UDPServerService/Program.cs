using UDPServerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<ServerService>();
    })
    .Build();

await host.RunAsync();

