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
    internal sealed class PostgresCarReadService : ICarReadService
    {
        private readonly DbSet<CarReadModel> _cars;
        
        public PostgresCarReadService(ReadDbContext readDbContext)
        {
            _cars = readDbContext.Cars;
        }

        public Task<bool> ExistsByLicensePlate(string licensePlate)
        {
            return _cars.AnyAsync(c => c.LicensePlate == licensePlate);
        }

        public Task<bool> ExistsByVIN(string vin)
        {
            return _cars.AnyAsync(c => c.Vin == vin);
        }
    }
}
