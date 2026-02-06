using Microsoft.EntityFrameworkCore;
using GameApi.Api.Endpoints;
using GameApi.Api.Persistence;
using GameApi.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// add swagger Services in program.cs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// here i need to read the Connection string: 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// register the DbContext with sqlServer
builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IGameService, GameService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.MapGameEndpoints();

app.MapGet("/", () => "Hallo Hahn")
    .Produces(200, typeof(string));

app.Run();

