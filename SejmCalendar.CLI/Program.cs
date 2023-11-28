using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SejmCalendar.Library;
using SejmCalendar.Library.DataAccess;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        services.AddHttpClient<ISejmDataAccess, SejmDataAccess>(client =>
        {
            client.BaseAddress = new Uri(config.GetValue<string>("API:Sejm:BaseUrl") ?? "");
        });
        services.AddSingleton<IBirthdayService, BirthdayService>();
    });

var host =  builder.Build();

await host.StartAsync();