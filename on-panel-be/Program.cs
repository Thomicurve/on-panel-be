using Application;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Common.Repository;
using Application.Mapper;
using Common;
using on_panel_be;
using Application.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.RequireHttpsMetadata = false; // Solo para desarrollo, usar HTTPS en producción
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Repositorio base
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

// Contexto de la aplicación
builder.Services.AddSingleton<OnPanelAppContext>();

// servicios -> proximamente autofac
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<OnPanelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WinConnection")));

var app = builder.Build();
app.UseMiddleware<AppContextMiddleware>();
app.MapControllers();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();



app.Run();
