using CQRSDemo.Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries;
using CQRSDemo.Repository;
using CQRSDemo.Repository.Interface;
using CQRSDEMO.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<CIPlatformContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("DbContext")));
builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IRequestHandler<GetAllUserQuery, List<User>>, GetAllUserHandler>();
builder.Services.AddTransient<IRequestHandler<AddUserDataCommand, UserAdd>, AddUserDataHandler>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
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
