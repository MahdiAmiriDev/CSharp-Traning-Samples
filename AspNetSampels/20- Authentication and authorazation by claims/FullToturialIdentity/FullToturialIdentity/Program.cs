using FullToturialIdentity.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);


//به میدل ور اعلام می کنیم که اسکیما نیم اهراز هویت ما چیست 
// اکر نکیم موقع دریافت ریکوست به مشکل برمیخوریم چون نمی تونه درست تشخیص بده
builder.Services.AddAuthentication("ByCookie").AddCookie("ByCookie", options =>
{
    options.Cookie.Name = "ByCookie";
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HasHrRole", policy =>
    {
        policy.RequireClaim("Department", "HR");
    });

    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireClaim("Admin");
    });
    //دوتا کلیم با هم اند می شوند و باید هردو را داشته باشد کاربر
    options.AddPolicy("HRManager", policy =>
    {
        policy.RequireClaim("Admin").RequireClaim("Department", "HR")
        .Requirements.Add(new HRManagerProbationRequirements(3));
    });
});


builder.Services.AddScoped<IAuthorizationHandler, HRManagerProbationRequirementsHandler>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
