using LearninBasics;

var builder = WebApplication.CreateBuilder(args);


var app = builder.ConfigureSrevices().ConfigurePipeline();

app.Map("/admin", map =>
{
    map.UseMiddleware<SercretMiddleWear>();
});

app.UseMiddleware<MyFirstMiddleWear>();


app.Run();
