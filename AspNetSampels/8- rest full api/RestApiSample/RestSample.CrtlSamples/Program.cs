using RestApiSample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
