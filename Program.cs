using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Models;
using ToDoApp.Data;
using ToDoApp.Services;
using ToDoApp.DTOs;
using ToDoApp.Controllers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});



builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserItemsService, UserItemsService>();
builder.Services.AddScoped<IUserItemsRepository, UserItemsRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IItemsService, ItemsService>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();

// Configurar la conexión con MySQL
var connectionString = $"Server={Environment.GetEnvironmentVariable("MYSQL_HOST")};" +
                       $"Port={Environment.GetEnvironmentVariable("MYSQL_PORT")};" +
                       $"Database={Environment.GetEnvironmentVariable("MYSQL_DB")};" +
                       $"Uid={Environment.GetEnvironmentVariable("MYSQL_USER")};" +
                       $"Pwd={Environment.GetEnvironmentVariable("MYSQL_PASSWORD")};";

builder.Services.AddDbContext<DbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
