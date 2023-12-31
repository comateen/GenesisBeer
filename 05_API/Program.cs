using _01_DB;
using _02_DAL.Interfaces;
using _02_DAL.Repositories;
using _04_SRV.Interfaces;
using _04_SRV.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Repos
builder.Services.AddScoped<IBeerRepository,BeerRepository>();
builder.Services.AddScoped<IBreweryRepository,BreweryRepository>();
builder.Services.AddScoped<IStockBeerWholesalerRepository,StockBeerWolesalerRepository>();
builder.Services.AddScoped<IWholesalerRepository, WholesalerRepository>();
builder.Services.AddScoped<IEstimateRepository, EstimateRepository>();
// Services
builder.Services.AddScoped<ILoggerService, LoggerService>();
builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddScoped<IBreweryService, BreweryService>();
builder.Services.AddScoped<IStockBeerWholesalerService, StockBeerWholesalerService>();
builder.Services.AddScoped<IWholesalerService,  WholesalerService>();
builder.Services.AddScoped<IEstimateService, EstimateService>();


//Config
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GenesisBeerDB")));

builder.Services.AddControllers();
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
