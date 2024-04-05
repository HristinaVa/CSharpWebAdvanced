using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<KindergartenDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddApplicationServices(typeof(IStatisticsService));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("KindergartenSystem", policyBuilder =>
    {
        policyBuilder
            .WithOrigins("https://localhost:7008")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("KindergartenSystem");

app.Run();
