using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Repositories
{
    public interface ICarRepository
    {
        Task<Car> GetAsync(VIN vin);
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(Car car);
    }
}
