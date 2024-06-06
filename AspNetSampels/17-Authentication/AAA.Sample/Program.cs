using AAA.Sample.Infra;
using AAA.Sample.Models;
using AAA.Sample.Requirements;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AAADbContext>(c => c.UseSqlServer("Server=.;Initial Catalog=AAA;Integrated Security= true"));
builder.Services.AddSingleton<IAuthorizationHandler, AgePolicyRequirementHandler>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(c =>
{
    //c.Password.RequireDigit = true;
    //c.Password.RequireLowercase = true;
    //c.Password.RequireUppercase = true;
}).AddEntityFrameworkStores<AAADbContext>().AddPasswordValidator<UserNameInPasswordValidator>();

//مربوط به تنظیمات اتن تیکیشن
//builder.Services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, opt =>
// {

// });

builder.Services.AddAuthorization(c =>
{
    c.AddPolicy("IsAdmin", pb =>
     {
         pb.RequireRole("Admin").RequireClaim("UserName", "mahdi");
     });

    c.AddPolicy("LigalAge", pb =>
    {
        pb.Requirements.Add(new AgePolicyRequirement(12));
    });
});

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
