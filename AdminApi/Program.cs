using Common;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.Core.Configuration;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGenericRepository>(new MongoRepository("mongodb://mamongo:27017", "AdminDatabase"));
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
