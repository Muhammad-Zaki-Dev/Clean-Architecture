using Application.Features.Categories.Command.Create;
using Application.Features.Categories.Command.Update;
using Application.Services;
using Domain.Generic;
using Infrastructure;
using Infrastructure.Presistance;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // WebAPI handlers (optional)
    cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly); // Application layer handlers
    cfg.RegisterServicesFromAssembly(typeof(UpdateCategoryCommand).Assembly); // Application layer handlers
});
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
