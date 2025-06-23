using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.DTOProjections;
using CarFleetIO.Infrastructure.EF.Models;
using CarFleetIO.Shared.Abstractions.Commands;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CarFleetIO.Infrastructure.EF.Queries.Handlers
{
    internal sealed class SearchCarByMakeHandler : IQueryHandler<SearchCarByMake, ICollection<CarDTO>>
    {
        private readonly DbSet<CarReadModel> _cars;

        public SearchCarByMakeHandler(ReadDbContext readDbContext)
        {
            _cars = readDbContext.Cars;
        }

        public async Task<ICollection<CarDTO>> HandleAsync(SearchCarByMake query)
        {
            var dbQuery = _cars
                .Include(u => u.User)
                .AsQueryable();

            if(query.Make is not null)
            {
                dbQuery = dbQuery.Where(c =>
                Microsoft.EntityFrameworkCore.EF.Functions.ILike(c.Make, $"%{query.Make}%"));
            }

            return await dbQuery
                .Select(c => c.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
