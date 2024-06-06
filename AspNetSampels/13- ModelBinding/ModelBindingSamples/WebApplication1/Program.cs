using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyMbDbContext>(c => c.UseSqlServer("Server=.;Initial Catalog=MBDataBase;Integrated Security=True"));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapRazorPages();


//app.MapGet("/", () => "Hello World!");

app.Run();
