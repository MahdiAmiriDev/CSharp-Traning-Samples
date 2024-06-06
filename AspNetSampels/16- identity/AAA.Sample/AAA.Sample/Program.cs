using AAA.Sample.Infra;
using AAA.Sample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AAADbContext>(c => c.UseSqlServer("Server=.;Initial Catalog=AAA;Integrated Security= true"));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(c =>
{
    //c.Password.RequireDigit = true;
    //c.Password.RequireLowercase = true;
    //c.Password.RequireUppercase = true;
}).AddEntityFrameworkStores<AAADbContext>().AddPasswordValidator<UserNameInPasswordValidator>();


var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
