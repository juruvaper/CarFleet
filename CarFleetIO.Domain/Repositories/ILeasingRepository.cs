using CarFleetIO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Repositories
{
    public interface ILeasingRepository
    {
        Task AddAsync(Leasing leasing);
    }
}
