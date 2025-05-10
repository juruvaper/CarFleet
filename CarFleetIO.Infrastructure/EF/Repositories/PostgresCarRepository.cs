using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Repositories
{
    internal sealed class PostgresCarRepository : ICarRepository
    {
        private readonly WriteDbContext _writeDbContext;
        private readonly DbSet<Car> _cars;

        public PostgresCarRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _cars = _writeDbContext.Cars;
        }

        public async Task AddAsync(Car car)
        {
            await _cars.AddAsync(car);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Car car)
        {
            _cars.Remove(car);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<Car> GetAsync(VIN vin)
        {
            return _cars.SingleOrDefaultAsync(v => v.Vin == vin);
        }

        public async Task UpdateAsync(Car car)
        {
             _cars.Update(car);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
