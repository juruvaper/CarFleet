using CarFleetIO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Repositories
{
    public interface ITripReportRepository
    {
        Task<TripReport> GetAsync(Guid id);
        Task AddAsync(TripReport tripReport);
        Task UpdateAsync(TripReport tripReport);
        Task DeleteAsync(TripReport tripReport);
    }
}
