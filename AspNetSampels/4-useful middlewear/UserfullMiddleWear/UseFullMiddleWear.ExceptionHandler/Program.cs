var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions
    {
        SourceCodeLineCount = 10
    });
}else if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/error.html");
}



app.UseStaticFiles();

app.MapGet("/ex", () =>
{
    throw new Exception("an exception raseid in my app");
});

app.MapGet("/", () => "Hello World!");

app.Run();
