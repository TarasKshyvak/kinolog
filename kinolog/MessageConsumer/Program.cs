using MassTransit;
using MessageConsumer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();

await Host.CreateDefaultBuilder(args)
.ConfigureServices(services =>
{
    services.AddMassTransit(x =>
    {
        x.AddConsumer<Consumer>();

        x.SetKebabCaseEndpointNameFormatter();

        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.ReceiveEndpoint("kinolog-queue", e =>
            {
                e.ConfigureConsumer<Consumer>(context);
            });

            cfg.ConfigureEndpoints(context);

            cfg.Host("localhost", "/", h => {
                h.Username("guest");
                h.Password("guest");
            });
        });
    });
})
.Build()
.RunAsync();