using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Text.Json.Serialization;
using testWebApiCore.DBContext;
using testWebApiCore.Interface;
using testWebApiCore.MapperProfile;
using testWebApiCore.Models;
using testWebApiCore.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//auto mapper services
//builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("constr")
    ));


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();

builder.Services.AddScoped<IBook,BookRepo>();

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
