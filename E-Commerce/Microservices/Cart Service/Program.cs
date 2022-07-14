using StackExchange.Redis;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
