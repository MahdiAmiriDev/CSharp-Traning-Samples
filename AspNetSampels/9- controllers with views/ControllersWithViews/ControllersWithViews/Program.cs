using ControllersWithViews.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PepoleDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("PepoleDb")));
builder.Services.AddScoped<IPepole,PepoleRepo>();
//builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();//.Add(c => ((RouteEndpointBuilder)c).Order = 2);
//app.MapDefaultControllerRoute();

//app.MapControllerRoute("Default", "{controller=Pepole}/{Action=GetAllPepole}/{id?}");

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.Run();
