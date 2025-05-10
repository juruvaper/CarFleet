using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Repositories
{
    internal class PostgresReservationRepository : IReservationRepository
    {

        private readonly WriteDbContext _writeDbContext;

        private readonly DbSet<Reservation> _reservations;

        public PostgresReservationRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _reservations = _writeDbContext.Reservations;
        }

        public async Task AddAsync(Reservation reservation)
        {
            await _reservations.AddAsync(reservation);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reservation reservation)
        {
            _reservations.Remove(reservation);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<Reservation> GetAsync(Guid id)
        {
            return await _reservations.FirstOrDefaultAsync(r => r.Id== id);
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _reservations.Update(reservation);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
