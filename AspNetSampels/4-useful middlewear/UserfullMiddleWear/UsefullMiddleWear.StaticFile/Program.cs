using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

//app.UseStaticFiles();

//ست کردن یک آدرس برای دسترسی به فایل های استاتیک
//app.UseStaticFiles("/staticFiles");

var rootPath = $"{app.Environment.ContentRootPath}\\MyStaticFile";

//ست کردن آدرس جدیدی به جای wwwroot برای پروژه
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(rootPath)
});

app.MapGet("/", () => "Hello World!");

app.Run();
