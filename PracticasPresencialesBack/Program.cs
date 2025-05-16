using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ToDoApp.Data;
using ToDoApp.Services;

Env.Load();                                   // 1) variables del .env

var builder = WebApplication.CreateBuilder(args);

// ---------- Kestrel ----------
builder.WebHost.ConfigureKestrel(o => o.ListenAnyIP(8080));

// ---------- MVC ----------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ---------- Swagger (DESPU�S de AddControllers) ----------
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RefuApi", Version = "v1" });

    // Bot�n �Authorize� con JWT en Swagger
    var jwtScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Scheme = "bearer",
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = JwtBearerDefaults.AuthenticationScheme
        }
    };
    c.AddSecurityDefinition(jwtScheme.Reference.Id, jwtScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtScheme, Array.Empty<string>() }
    });
});

// ---------- cadena de conexi�n MySQL ----------
var connectionString =
    $"Server={Environment.GetEnvironmentVariable("MYSQL_HOST")};" +
    $"Port={Environment.GetEnvironmentVariable("MYSQL_PORT")};" +
    $"Database={Environment.GetEnvironmentVariable("MYSQL_DB")};" +
    $"Uid={Environment.GetEnvironmentVariable("MYSQL_USER")};" +
    $"Pwd={Environment.GetEnvironmentVariable("MYSQL_PASSWORD")};";

builder.Services.AddDbContext<QuestifyContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// ---------- AutoMapper ----------
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// ---------- Repositorios y servicios ----------
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IItemsService, ItemsService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserItemsRepository, UserItemsRepository>();
builder.Services.AddScoped<IUserItemsService, UserItemsService>();

// ---------- JWT ----------
var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET")
                ?? throw new InvalidOperationException("JWT_SECRET no est� definido");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
            ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };

        options.Events = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                var json = System.Text.Json.JsonSerializer.Serialize(new
                {
                    message = "Unauthorized: token is missing or invalid."
                });
                return context.Response.WriteAsync(json);
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("VeteranOnly", p => p.RequireClaim("IsVeteran", "true"));
});

// ---------- CORS ----------
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AllowFrontend", p =>
        p.WithOrigins("http://localhost:5173", "http://localhost:8080")
         .AllowAnyHeader()
         .AllowAnyMethod());
});

var app = builder.Build();

// ---------- pipeline ----------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
