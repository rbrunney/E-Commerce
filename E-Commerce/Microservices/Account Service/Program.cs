using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<AccountDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db2")));
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

app.Run();
