using Quartz;
using QuartzSample.Jobs;
using QuartzSample.Sesrvices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<PostService>();
builder.Services.AddQuartz(c =>
{
    c.UseMicrosoftDependencyInjectionJobFactory();
    var jobKey = new JobKey("Post To File Job");
    c.AddJob<PostTofFileJob>(j =>
    {
        j.WithIdentity(jobKey);
    });
    c.AddTrigger(t =>
    {
        t.ForJob(jobKey);
        t.WithIdentity("Post to file job trigger").StartNow();
        t.WithSimpleSchedule(s =>
        {
            s.WithInterval(TimeSpan.FromSeconds(15));
            s.RepeatForever();
        });
    });
});
builder.Services.AddQuartzHostedService(c =>
{
    c.WaitForJobsToComplete = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
