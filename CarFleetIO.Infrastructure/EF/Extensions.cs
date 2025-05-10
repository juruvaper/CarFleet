using CarFleetIO.Application.Services;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.Options;
using CarFleetIO.Infrastructure.EF.Repositories;
using CarFleetIO.Infrastructure.EF.Services;
using CarFleetIO.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF
{
    public static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            /*services.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
            services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();
            */

            services.AddScoped<ICarRepository, PostgresCarRepository>();
            services.AddScoped<IUserRepository, PostgresUserRepository>();
            services.AddScoped<ITripReportRepository, PostgresTripReportRepository>();
            services.AddScoped<ILeasingRepository,  PostgresLeasingRepository>();
            services.AddScoped<IReservationRepository, PostgresReservationRepository>();
            services.AddScoped<ILocalizationRepository, PostgresLocalizationRepository>();

            services.AddScoped<ICarReadService, PostgresCarReadService>();
            services.AddScoped<IUserReadService,  PostgresUserReadService>();
            services.AddScoped<IReservationReadService, PostgresReservationReadService>();
            services.AddScoped<ILeasingReadService, PostgresLeasingReadService>();


            var options = configuration.GetOptions<PostgresOptions>("Postgres");
            services.AddDbContext<ReadDbContext>(
                ctx => ctx.UseNpgsql(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(
               ctx => ctx.UseNpgsql(options.ConnectionString));

            return services;

        }
    }
}
