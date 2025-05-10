using CarFleetIO.Infrastructure.EF;
using CarFleetIO.Shared.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure
{
    public static class Extensions
    {
       
            public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddPostgres(configuration);
                services.AddQueries();

                return services;

            }
        }
    
}
