using Microsoft.EntityFrameworkCore;
using StudentAnalytics.Context;
using Microsoft.AspNetCore.Identity;
using StudentAnalytics.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordHasher<UserController>, PasswordHasher<UserController>>();

var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD", EnvironmentVariableTarget.User)
    ?? throw new InvalidOperationException("Database password not found in environment variables.");

// if cloned, user secrets will need to be set up on local environment
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StudentAnalyticsSystemContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();