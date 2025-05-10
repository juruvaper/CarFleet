using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Repositories
{
    internal class PostgresLeasingRepository : ILeasingRepository
    {
        public Task AddAsync(Leasing leasing)
        {
            throw new NotImplementedException();
        }
    }
}
