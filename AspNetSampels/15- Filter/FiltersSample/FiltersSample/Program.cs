var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddRazorPages();
var app = builder.Build();
app.UseStaticFiles();
app.UseStatusCodePages();
app.MapDefaultControllerRoute();
app.MapRazorPages();


app.Run();
