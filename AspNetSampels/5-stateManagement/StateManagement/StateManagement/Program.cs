using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
//builder.Services.AddDistributedSqlServerCache(config =>
//{
//    config.SchemaName = "dbo";
//    config.TableName = "DataCache";
//    config.ConnectionString = "Server=.;Database=Cache;Integrated Security = true";
//});
builder.Services.AddSession(c =>
{
    c.IdleTimeout = TimeSpan.FromSeconds(120);
});


var app = builder.Build();

app.UseSession();

app.MapGet("/", () => "Hello World!");


app.Map("/sessionId", async (Context) =>
{
    var sessionId = Context.Session.Id;
    Context.Response.StatusCode = 200;
    Context.Response.ContentType = "text/html";
    await Context.Response.WriteAsync(sessionId);
});


app.Map("/session", async (Context) =>
{
    int num = 0;
    num = Context.Session.GetInt32(nameof(num)) ?? 0;
    num++;

    Context.Session.SetInt32(nameof(num), num);
    Context.Response.ContentType = "text/html";
    await Context.Response.WriteAsync(num.ToString());
});



//app.MapGet("/distributedcache", async (HttpContext context, IDistributedCache cache) =>
//{
//    int num1 = 0;
//    string numKey = nameof(num1);


//    num1 = int.Parse(cache.GetString(numKey) ?? "0");
//    num1++;


//    cache.SetString(numKey, num1.ToString(), new DistributedCacheEntryOptions
//    {
//        AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120),
//        SlidingExpiration = TimeSpan.FromMinutes(1)
//    });

//    context.Response.StatusCode = 200;
//    context.Response.ContentType = "text/html";
//    await context.Response.WriteAsync(num1.ToString());
//});

//app.MapGet("/cache", async (HttpContext context, IMemoryCache cache) =>
//{
//int num1 = 0;
//string numKey = nameof(num1);



//num1 = cache.Get<int>(numKey);
//num1++;


//cache.Set(numKey, num1, new MemoryCacheEntryOptions
//{
//    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120),
//    SlidingExpiration = TimeSpan.FromMinutes(1)
//});

//context.Response.StatusCode = 200;
//context.Response.ContentType = "text/html";
//await context.Response.WriteAsync(num1.ToString());
//});


app.Map("/cookie", async (context) =>
{
    int number = 0;
    int number2 = 0;

    number = int.Parse(context.Request.Cookies[nameof(number)] ?? "0");
    number2 = int.Parse(context.Request.Cookies[nameof(number2)] ?? "0");

    number++;
    number2++;

    context.Response.Cookies.Append(nameof(number), number.ToString());
    context.Response.Cookies.Append(nameof(number2), number2.ToString(),new CookieOptions
    {
        Expires = DateTime.Now.AddSeconds(5),
        IsEssential = true,        
    });

    context.Response.ContentType = "text/html";

    await context.Response.WriteAsync($"<h2>{number}---{number2}</h2>");
});

app.Map("/clear", (HttpContext context) =>
{
    context.Response.Cookies.Delete("number");
});

app.Run();
