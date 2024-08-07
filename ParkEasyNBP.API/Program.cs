﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Neo4jClient;
using ParkEasyNBP.API.Middlewares;
using ParkEasyNBP.Application.Mapping;
using ParkEasyNBP.Application.Services;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.ModelsMongoDB;
using ParkEasyNBP.Infrastructure.MongoDB;
using ParkEasyNBP.Infrastructure.Neo4j.Services;
using ParkEasyNBP.Infrastructure.SqlServer;
using Repository;
using Repository.Neo4jRepositories;
using Repository.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//SQL server
builder.Services.AddDbContext<ParkDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ParkEasyContext")));

builder.Services.AddScoped<IParkingPlaceRepository, ParkingPlaceRepository>();
builder.Services.AddScoped<IZoneRepository, ZoneRepository>();
//builder.Services.AddScoped<IZoneRepository, ZoneGraphRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ParkingPlaceService>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IPenaltyRepository, PenaltyRepository>();
builder.Services.AddScoped<IControlRepository, ControlRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
  //dodavanje MediatR-a
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<Program>();
    cfg.Lifetime = ServiceLifetime.Scoped;
});



//MONGO DB
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDbSettings"));

  // Registracija MongoDB klijenta
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});
builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));


//Neo4J
//var client = new GraphClient(new Uri("http://93f260b7.databases.neo4j.io:7687"), "neo4j", "LSH_QeDZwjMxAKBgnltZijCmFoGEL5ghJszj-peGjZ4");
var client = new BoltGraphClient(new Uri("bolt+s://93f260b7.databases.neo4j.io:7687"), "neo4j", "LSH_QeDZwjMxAKBgnltZijCmFoGEL5ghJszj-peGjZ4");
await client.ConnectAsync();
builder.Services.AddSingleton<IGraphClient>(client);

//builder.Services.AddSingleton<ZonesService>();


//JWT
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ParkDbContext>()
    .AddDefaultTokenProviders();
/*builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ParkDbContext>()
    .AddDefaultTokenProviders();*/
builder.Services.AddScoped<ParkingPlaceService>();
builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    )
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidAudience = "https://localhost:5001/",
            ValidIssuer = "https://localhost:5001/",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("78fUjkyzfLz56gTq78fUjkyzfLz56gTq"))
        };
    });

builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomMiddleware();
//app.UseMyMiddleware();
app.MapControllers();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.Run();
/*builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDb");
    return new MongoClient(connectionString);
});

builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("ParkEasyProject");
});*/

// Registrujte generički repozitorijum
/*builder.Services.AddScoped(typeof(MongoRepository<>));
builder.Services.AddScoped<ZoneService>();*/
//builder.Services.AddScoped<IZoneService, ZoneService>();
/*builder.Services.AddScoped<MongoService>();
builder.Services.AddScoped<ParkingPlaceServiceMongoDB>();*/