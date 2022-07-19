using Microsoft.EntityFrameworkCore;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<CartDB>(opt => opt.UseInMemoryDatabase("Cart"));
builder.Services.AddDiscoveryClient(builder.Configuration);
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

app.MapGet("/", () => "Hello World!");

app.Run();
