using Carter;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RideIt.Features.Users;
using RideIt.Infrastructure;
using RideIt.Services;
using RideIt.Services.Abstraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RideItDbContext>(opt =>
{
    opt.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connections string is not defined"));
});

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddScoped<IFileSystemService, FileSystemService>();
builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<IPasswordHasher<User>,PasswordHasher<User>>();
builder.Services.AddCarter();
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
app.MapCarter();

app.Run();
