using Microsoft.EntityFrameworkCore;
using ModelValidation.Sample.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ValidationDbContext>(c => c.UseSqlServer("Server=.;Initial Catalog=ValidationDb;Integrated Security=True"));
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();

//app.MapGet("/", () => "Hello World!");

app.Run();
