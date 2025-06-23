using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CarFleetIO.Api;
using CarFleetIO.Application;
using CarFleetIO.Application.Commands;
using CarFleetIO.Infrastructure;
using CarFleetIO.Infrastructure.EF.AppInit;
using CarFleetIO.Infrastructure.EF.Identity;
using CarFleetIO.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddShared();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddTransient<ICommandHandler<RegisterUser>, RegisterUserHandler>();



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalDevelopment", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173")
               
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // Optional: if using cookies/auth
    });
});


builder.Services.AddAuthentication()/*AddCookie(IdentityConstants.ApplicationScheme)*/
    .AddBearerToken(IdentityConstants.BearerScheme);


builder.Services.AddAuthorization();

builder.Services.AddIdentityCore<UserIdentity>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<UserManagerDbContext>()
    .AddApiEndpoints();




builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<UserManagerDbContext>(options => options.UseNpgsql("Host=localhost;Database=Identity;Username=postgres;Password="));

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseCors("LocalDevelopment");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();//.RequireAuthorization();
app.MapIdentityApi<UserIdentity>();


app.Run();