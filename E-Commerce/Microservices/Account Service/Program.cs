using Microsoft.EntityFrameworkCore;
using Steeltoe.Discovery.Client;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Discovery;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<AccountDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db2")));
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

app.MapGet("/", () => "To access the account api please enter /account/help for more information ");
app.MapGet("/catalogitems", async (IDiscoveryClient idc) =>
{
//return "this is the root of dotnet-eureka-client";
    DiscoveryHttpClientHandler _handler = new DiscoveryHttpClientHandler(idc);
    var client = new HttpClient(_handler, false);
    return await client.GetStringAsync("http://CATALOG-SERVICE/ecommerce/getallitems");
}
);

app.Run();
