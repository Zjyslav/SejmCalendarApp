using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SejmCalendar.Library.DataAccess;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        services.AddSingleton<SejmDataAccess>();
        services.AddHttpClient<SejmDataAccess>(client =>
        {
            client.BaseAddress = new Uri(config.GetValue<string>("API:Sejm:BaseUrl") ?? "");
        });
    });

var host =  builder.Build();

await host.StartAsync();