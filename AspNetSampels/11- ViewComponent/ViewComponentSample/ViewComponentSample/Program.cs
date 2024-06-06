

using ViewComponentSample.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NewsDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.MapGet("/", () => "Hello World!");

app.Run();
