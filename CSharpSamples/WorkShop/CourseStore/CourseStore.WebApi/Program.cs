using CourseStore.DAL;
using CourseStore.DAL.FrameWork;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CourseStore.BLL.Tags.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<CourseStoreDbContext>(c =>
{
    c.UseSqlServer("server=.;Initial Catalog=CourseStoreClearSolutionDb;Integrated Security=true")
    .AddInterceptors(new AddAuditFieldInterceptors());

});
builder.Services.AddMediatR(typeof(CreateTagHandler).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
