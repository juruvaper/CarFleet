using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Services
{
    public interface IUserReadService
    {
        Task<bool> ExistsByUsername(string username);
        Task<bool> ExistsBySecurityNumber(long securityNumber);

    }
}
