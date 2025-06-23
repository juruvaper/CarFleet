using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.DTOProjections;
using CarFleetIO.Infrastructure.EF.Models;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CarFleetIO.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllCarsHandler : IQueryHandler<GetAllCars, ICollection<CarDTO>>
    {
        private readonly DbSet<CarReadModel> _cars;

        public GetAllCarsHandler(ReadDbContext readDbContext)
        {
            _cars = readDbContext.Cars;
        }

        public async Task<ICollection<CarDTO>> HandleAsync(GetAllCars query)
        {
            return await _cars.Include(u=> u.User).Select(p => p.AsDto()).AsNoTracking().ToListAsync();
        }
    }
}
