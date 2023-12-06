using SejmCalendar.Blazor;
using SejmCalendar.Blazor.Components;
using SejmCalendar.Library;
using SejmCalendar.Library.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<ISejmDataAccess, SejmDataAccess>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("API:Sejm:BaseUrl") ?? "");
});
builder.Services.AddSingleton<IBirthdayService, BirthdayService>();
builder.Services.AddScoped<IDateService, DateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
