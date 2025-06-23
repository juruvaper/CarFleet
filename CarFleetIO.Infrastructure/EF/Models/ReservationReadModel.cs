using CarFleetIO.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Models
{
    internal class ReservationReadModel
    {
        public Guid Id { get; set; }
        public DateOnly ReservationDates_StartDate { get; set; }
        public DateOnly ReservationDates_EndDate { get; set; }
        public string CarIdentifier { get; set; }
        public string UserIdentifier { get; set; }
        public string StartCity { get; set; }
        public string DestinationCity { get; set; }
        public bool Finished { get; set; }


        //

        public virtual CarReadModel Car { get; set; }
    }
}
