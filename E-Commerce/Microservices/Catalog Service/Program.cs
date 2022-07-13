using Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.Configure<ItemDatabaseSettings>(builder.Configuration.GetSection("ItemDatabase"));
builder.Services.AddSingleton<Ser.ItemService2>();

var app = builder.Build();
app.MapControllers();

app.Run();
//mongodb://EC:abc123!!@@localhost:27017