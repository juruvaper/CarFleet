using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Services
{
    public interface IReservationReadService
    {
        Task<bool> ExistsByCarAndDates(string VIN, DateOnly startDate, DateOnly endDate);
    }
}
