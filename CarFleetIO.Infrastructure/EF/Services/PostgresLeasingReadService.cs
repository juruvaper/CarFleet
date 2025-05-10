using CarFleetIO.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Services
{
    internal class PostgresLeasingReadService : ILeasingReadService
    {
        public Task<bool> ExistsByLeaseId(Guid leaseId)
        {
            throw new NotImplementedException();
        }
    }
}
