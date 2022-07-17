using Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.Configure<ItemDatabaseSettings>(builder.Configuration.GetSection("ItemDatabase"));
builder.Services.AddSingleton<Ser.ItemService2>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            policy.WithHeaders("Access-Control-Allow-Origin", "*");
        });
});

var app = builder.Build();
app.MapControllers();
app.UseCors();

app.Run();
//mongodb://EC:abc123!!@@localhost:27017