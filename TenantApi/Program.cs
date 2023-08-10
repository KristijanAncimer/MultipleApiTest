// <copyright file="Program.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

using System.Reflection;
using Common;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string mongoConnectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string mongoDatabase = Environment.GetEnvironmentVariable("MONGO_DATABASE");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

if (string.IsNullOrEmpty(mongoConnectionString))
{
    throw new ArgumentException(" Mongo connection string must be set");
}

if (string.IsNullOrEmpty(mongoDatabase))
{
    throw new ArgumentException(" Mongo database must be set");
}

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IRepository>(new MongoRepository(mongoConnectionString, mongoDatabase));

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
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