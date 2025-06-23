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
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarFleetIO.Infrastructure.EF.Queries.Handlers
{

    internal sealed class GetMyReservationsHandler : IQueryHandler<GetMyReservations,IEnumerable<ReservationDTO>>
    {
        private readonly DbSet<ReservationReadModel> _reservations;
        private IHttpContextAccessor _contextAccessor;

        public GetMyReservationsHandler(ReadDbContext readDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
            _reservations = readDbContext.Reservations;
        }

        public async Task<IEnumerable<ReservationDTO>> HandleAsync(GetMyReservations query)
        {
            var user = _contextAccessor.HttpContext.User;
            if(user == null)
            {
                throw new ArgumentNullException("User not found");
            }

            return await _reservations.Where(r => r.UserIdentifier == user.Identity.Name)
                .Include(r => r.Car)
                .Select(r => r.AsDto())
                .AsNoTracking()
                .ToListAsync();

        }

    }
}
