using Application;
using Infraestructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// servicios -> proximamente autofac
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDbContext<OnPanelContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MacConnection"), 
        new MySqlServerVersion(new Version(8, 0, 28)),
            builder => builder.MigrationsAssembly(typeof(Program).Assembly.FullName))
);

var app = builder.Build();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();



app.Run();
