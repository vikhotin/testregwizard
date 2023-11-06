using Microsoft.EntityFrameworkCore;
using Regwizard.Db;
using Regwizard.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<Context>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Context")));

var app = builder.Build();

app.MapControllers();

app.Run();
