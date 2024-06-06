using Newtonsoft.Json;
using RestApiSample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/GetProduct", async (HttpContext context , ProductDbContext dbContext) =>
 {
     var productList = dbContext.Products.ToList();
     context.Response.StatusCode = 200;

     //var productsString = JsonConvert.SerializeObject(productList);

     await context.Response.WriteAsJsonAsync(productList);


 });


app.Run();
