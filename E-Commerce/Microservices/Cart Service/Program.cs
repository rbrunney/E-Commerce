using StackExchange.Redis;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var multiplexer = ConnectionMultiplexer.Connect("localhost");
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
