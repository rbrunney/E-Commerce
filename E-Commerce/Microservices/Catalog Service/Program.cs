using Model;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDiscoveryClient(builder.Configuration);

builder.Services.Configure<ItemDatabaseSettings>(builder.Configuration.GetSection("ItemDatabase"));
builder.Services.AddSingleton<Ser.ItemService2>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
var app = builder.Build();
app.MapControllers();
app.UseCors();

app.Run();
//mongodb://EC:abc123!!@@localhost:27017