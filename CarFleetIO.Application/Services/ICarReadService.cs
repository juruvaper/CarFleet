using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Services
{
    public interface ICarReadService
    {
        Task<bool> ExistsByVIN(string vin);
        Task<bool> ExistsByLicensePlate(string licensePlate);
    }
}
