using Microsoft.EntityFrameworkCore;
using System;
using API.db;
using API;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = "Server=localhost;Database=MyBase;User=Noitorra;Password=Passw0rd;trustservercertificate=True";
builder.Services.AddDbContext<appContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Authorization autho = new Authorization();
app.MapGet("/api/authorization", (string login, string password) => autho.Autho(login, password));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
