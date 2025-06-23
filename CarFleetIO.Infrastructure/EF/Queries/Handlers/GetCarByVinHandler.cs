using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.DTOProjections;
using CarFleetIO.Infrastructure.EF.Models;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("Tests")]

namespace CarFleetIO.Infrastructure.EF.Queries.Handlers
{

    internal sealed class GetCarByVinHandler : IQueryHandler<GetCarByVin, CarDTO>
    {
        private readonly DbSet<CarReadModel> _cars;



        public GetCarByVinHandler(ReadDbContext context)
        {
            _cars = context.Cars;
        }

        public async Task<CarDTO> HandleAsync(GetCarByVin query)
        {
            return await _cars
                .Include(u => u.User)
                .Where(c => c.VIN == query.Vin)
                .Select(p=> p.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
    }
}
