
using DependncyInjectionSample.DiSample;
using DependncyInjectionSample.FactorySample;
using System;

var builder = WebApplication.CreateBuilder(args);

//تزریق وابستگی به اپلیکیشن
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IDiChainSample, DiChainSample>();
builder.Services.AddSingleton<ConcredDi>();
builder.Services.AddTransient<IFactoryService>(s =>
{
    bool isEvent = (DateTime.Now.Second % 2 == 0);

    if (isEvent)
        return new FirstOne();


    return new Second();

});



var app = builder.Build();

app.MapGet("/factory", async (HttpContext context, IFactoryService repository) =>
{
    await context.Response.WriteAsync(repository.GetImplementationClassName());
});

app.MapGet("/service", async (HttpContext context, IUserRepository repository) =>
 {
     await context.Response.WriteAsync(repository.GetGuid());
 });

app.MapGet("/chain", async (HttpContext context, IUserRepository repository) =>
{
    await context.Response.WriteAsync(repository.GetChainGuid());
});

app.MapGet("/concred", async (HttpContext context, ConcredDi repository) =>
{
    await context.Response.WriteAsync(repository.GetDeveloperName());
});

app.MapGet("/transient", async (HttpContext context, IOrderRepository repository, IOrderRepository repository2) =>
{
    await context.Response.WriteAsync($"{repository.GetGuid()} === {repository.GetGuid()} {Environment.NewLine}");
    await context.Response.WriteAsync($"{repository2.GetGuid()} === {repository2.GetGuid()}");
});

app.MapGet("/", () => "Hello World!");

app.Run();
