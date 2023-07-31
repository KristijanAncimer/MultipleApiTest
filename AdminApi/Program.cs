using Common;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.Core.Configuration;
using System.Xml.Linq;

string mongoConnectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
string mongoDatabase = Environment.GetEnvironmentVariable("MONGO_DATABASE");

if (string.IsNullOrEmpty(mongoConnectionString))
{
    throw new ArgumentException(" Mongo connection string must be set");
}
if (string.IsNullOrEmpty(mongoDatabase))
{
    throw new ArgumentException(" Mongo database must be set");
}

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGenericRepository>(new MongoRepository(mongoConnectionString, mongoDatabase));
// Add services to the container.
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

app.UseAuthorization();

app.MapControllers();

app.Run();
