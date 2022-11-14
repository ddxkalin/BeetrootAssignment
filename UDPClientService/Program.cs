using UDPClientService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<ClientService>();
    })
    .Build();

await host.RunAsync();

