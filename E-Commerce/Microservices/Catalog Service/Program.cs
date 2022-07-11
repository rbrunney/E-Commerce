using Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.Configure<ItemDatabaseSettings>(builder.Configuration.GetSection("ItemDb"));

builder.Services.AddSingleton<ItemService>();

app.MapGet("/", () => "Hello World!");

app.Run();
