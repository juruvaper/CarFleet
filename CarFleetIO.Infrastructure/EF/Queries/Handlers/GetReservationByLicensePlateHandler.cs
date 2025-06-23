using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.DTOProjections;
using CarFleetIO.Infrastructure.EF.Models;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Queries.Handlers
{
    internal class GetReservationByLicensePlateHandler : IQueryHandler<GetReservationByLicensePlate, IEnumerable<ReservationDTO>>
    {
        private readonly DbSet<ReservationReadModel> _reservations;

        public GetReservationByLicensePlateHandler(ReadDbContext readDbContext)
        {
            _reservations = readDbContext.Reservations;
        }

        public async Task<IEnumerable<ReservationDTO>> HandleAsync(GetReservationByLicensePlate query)
        {

            return await _reservations.Where(r => r.Car.LicensePlate == query.LicensePlate)
                .Select(r => r.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
