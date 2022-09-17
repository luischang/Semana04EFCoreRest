using Microsoft.EntityFrameworkCore;
using Semana04EFCoreRest.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Get ConnectionString
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
//Add DbContext
builder
    .Services
    .AddDbContext<MundialQatar2022SinPeruContext>
    (options => options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
