using Microsoft.AspNetCore.Routing;
using UrlRoutingSample.MiddleWear;
using UrlRoutingSample.RoutingConstraint;

var builder = WebApplication.CreateBuilder(args);

//ریجستر کردن یک شرط برای مسیر
builder.Services.Configure<RouteOptions>(opt =>
{
    opt.ConstraintMap.Add("nc", typeof(NationalCode));
});

var app = builder.Build();

//app.UseMiddleware<MavadeLazem>();
//app.UseMiddleware<TarzeTahieh>();

app.UseRouting();


//ست کردن فال بک برای حالتی که هیچ کدام از مسیر ها به کار نایند
app.MapFallback(async context =>
{
    await context.Response.WriteAsync("there is no contetn for this request");
});

//مسیر به همراه شرط خاص ساخته شده توسط ما
app.Map("/ncode/{code:nc}", async (context) =>
{
    var data = context.Request.RouteValues;

    foreach (var item in data)
    {
        await context.Response.WriteAsync($"{item.Value} {Environment.NewLine}");
    }
});

//مسیر به همراه شرط های دلخواه
app.Map("/{one}/{two:length(5)}/{three:bool}", async (context) =>
{
    var data = context.Request.RouteValues;

    foreach (var item in data)
    {
        await context.Response.WriteAsync($"{item.Value} {Environment.NewLine}");
    }
}).Add(c => ((RouteEndpointBuilder)c).Order = 1);

//مسیر به همراه ورودی نال پذیر و مقدار پیش فرض و پارامتر اجباری
app.Map("/{one}/{two=2}/{three?}", async (context) =>
 {
     var data = context.Request.RouteValues;

     foreach (var item in data)
     {
         await context.Response.WriteAsync($"{item.Value} {Environment.NewLine}");
     }
 });

//نوع خاصی برای دریافت مسیر
app.Map("/io/{fileName}.{extenstion}/t",async (context) =>
{
    var data = context.Request.RouteValues;

    foreach(var item in data)
    {
        await context.Response.WriteAsync($"{item.Value} {Environment.NewLine}");
    }
});

// استفاده از عندپوینت برای مسیر و شناسایی میدل ور ساخته شده به عنوان مسیر 
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/mv/Nimroo", new MavadeLazem().Invoke);
    endpoints.Map("/tt/Kotlet", new TarzeTahieh().Invoke);
    endpoints.MapGet("/test", async (httpContext) =>
     {
         await httpContext.Response.WriteAsync("this is my map get");
     });
});

app.MapGet("/{one}/{two}/{three}", async (context) =>
{
    var data = context.Request.RouteValues;

    foreach(var item in data)
    {
        await context.Response.WriteAsync($"my value is {item.Value}");
    }

});

app.Map("/{name}", new CustomVariableMiddleWear().InvokeAsync);


app.Run(async (httpContext) =>
{
    await httpContext.Response.WriteAsync("terminal response");
});

app.Run();
