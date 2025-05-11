using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using CarFleetIO.Application;
using CarFleetIO.Infrastructure;
using CarFleetIO.Shared;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using CarFleetIO.Infrastructure.EF.Identity;
using Microsoft.EntityFrameworkCore;
using CarFleetIO.Infrastructure.EF.AppInit;

namespace CarFleetIO.Api
{
    

        public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            public void ConfigureServices(IServiceCollection services)
            {

                //Application layer jest odpowiedzialna za rejestrację obiektów na szczeblu domeny

                services.AddShared();

            services.AddEndpointsApiExplorer();
            services.AddAuthorization();
            services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
                .AddBearerToken(IdentityConstants.BearerScheme);

            services.AddIdentityCore<UserIdentity>()
                .AddEntityFrameworkStores<UserManagerDbContext>()
                .AddApiEndpoints();

            services.AddDbContext<UserManagerDbContext>(options => options.UseNpgsql("Host=localhost;Database=Identity;Username=postgres;Password="));
                services.AddApplication();
                services.AddInfrastructure(Configuration);
                services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                });

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarFleetIO.Api", Version = "v1" });
                });
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PackIT.Api v1"));
                    app.ApplyMigrations();
                }

                
                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthentication();
                app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapIdentityApi<UserIdentity>(); // <-- This is the missing piece
            });

        }
    }
    }

