using CarFleetIO.Application.Services;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Services
{
    internal class PostgresReservationReadService : IReservationReadService
    {

        private DbSet<ReservationReadModel> _reservations;

        public PostgresReservationReadService(ReadDbContext readDbContext)
        {
            _reservations = readDbContext.Reservations;
        }

        public Task<bool> ExistsByCarAndDates(string VIN, DateOnly startDate, DateOnly endDate)
            => _reservations.AnyAsync(c => c.CarIdentifier == VIN && c.ReservationDates_StartDate <= endDate && c.ReservationDates_EndDate >= startDate);
            
        

    }
}
