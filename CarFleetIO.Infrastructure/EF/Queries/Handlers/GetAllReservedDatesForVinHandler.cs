using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetIO.Application.Queries;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.Models;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CarFleetIO.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllReservedDatesForVinHandler : IQueryHandler<GetAllReservedDatesForVin, List<string>>
    {
        private readonly DbSet<ReservationReadModel> _reservations;

        public GetAllReservedDatesForVinHandler(ReadDbContext readDbContext)
        {
            _reservations = readDbContext.Reservations;
        }

        public async Task<List<string>> HandleAsync(GetAllReservedDatesForVin query)
        {
            HashSet<DateOnly> dateResult = new HashSet<DateOnly>();

            var reservationsResult = await _reservations.
                Where(c => c.CarIdentifier == query.Vin).
                AsNoTracking().
                ToListAsync();

            foreach (var result in reservationsResult)
            {
                for (var date = result.ReservationDates_StartDate; date <= result.ReservationDates_EndDate; date = date.AddDays(1))
                {
                    dateResult.Add(date);
                }

            }

            return dateResult
                    .OrderBy(d => d)
                    .Select(d => d.ToString("yyyy-MM-dd"))
                    .ToList();
        }
    }
}
