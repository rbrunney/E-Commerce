using Model;
using Steeltoe.Discovery.Client;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Discovery;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.Configure<ItemDatabaseSettings>(builder.Configuration.GetSection("ItemDatabase"));
builder.Services.AddSingleton<Ser.ItemService2>();

var app = builder.Build();
app.MapControllers();

app.Run();
//mongodb://EC:abc123!!@@localhost:27017