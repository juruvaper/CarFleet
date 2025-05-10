using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Repositories
{
    internal class PostgresTripReportRepository : ITripReportRepository
    {
        public Task AddAsync(TripReport tripReport)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TripReport tripReport)
        {
            throw new NotImplementedException();
        }

        public Task<TripReport> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TripReport tripReport)
        {
            throw new NotImplementedException();
        }
    }
}
