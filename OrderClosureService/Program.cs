using CreditRegistrationCommon;
using OrderClosureService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<IOrderCloseService, OrderCloseService>();
    })
    .Build();

await host.RunAsync();
