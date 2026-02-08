using Microsoft.EntityFrameworkCore;
using Praktika.Praktika.Infrastructure.Persistence;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PraktikaDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("myConfing")));

// Register MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Praktika.Application.Categories.Commands.CreateCategory.CreateCategoryCommand).Assembly);
});

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register FluentValidation validators
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Console.WriteLine($"ENV = {builder.Environment.EnvironmentName}");

app.Run();
