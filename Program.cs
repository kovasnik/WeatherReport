using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeatherReport.BLL.Interfaces;
using WeatherReport.BLL.Services;
using WeatherReport.Data;
using WeatherReport.Data.Interfaces;
using WeatherReport.Data.Repository;
using WeatherReport.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<WeatherReportDbSettings>(
    builder.Configuration.GetSection("WeatherReportDatabase"));

builder.Services.AddSingleton<IMongoClient>(c =>
{
    var settings = c.GetRequiredService<IOptions<WeatherReportDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<WeatherReportDbContext>();

builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

builder.Services.AddScoped<IWeatherService, WeatherService>();

builder.Services.AddHttpClient();

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
