using TaskManager.BLL.Interfaces;
using TaskManager.BLL.Models;
using TaskManager.BLL.Services;
using TaskManager.DAL.Abstract;
using TaskManager.DAL.Context;
using TaskManager.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using TaskManager.DAL.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ITaskManagerSettings settings = builder.Configuration.GetSection(nameof(TaskManagerSettings)).Get<TaskManagerSettings>();

builder.Services.AddSingleton(settings);

builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("DatabaseContext"), ServiceLifetime.Singleton);
builder.Services.AddHttpClient();

//builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddSingleton<DbUtils>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();



builder.Services.AddSingleton<IOpenAIService, OpenAIService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ITaskService, TaskService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
   // c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMiddleware<AuthorizationMiddleware>("1234");
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthentication();
//app.UseAuthorization();

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
