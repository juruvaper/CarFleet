using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.DTO
{
    public class ReservationDTO
    {
        public Guid Id;
        public DateOnly ReservationDates_StartDate;
        public DateOnly ReservationDates_EndDate;
        public string UserIdentifier;
        public string CarIdentifier;
        public string StartCity;
        public string DestinationCity;
        public bool Finished;
        public CarDTO Car;
    }
}
