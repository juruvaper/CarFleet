using System;

namespace CarFleetIO.Application.DTO
{
    public class ReservationDTO
    {
        public Guid Id { get; set; }
        public DateOnly ReservationDates_StartDate { get; set; }
        public DateOnly ReservationDates_EndDate { get; set; }
        public string UserIdentifier { get; set; }
        public string CarIdentifier { get; set; }
        public string StartCity { get; set; }
        public string DestinationCity { get; set; }
        public bool Finished { get; set; }
        public CarDTO Car { get; set; }
    }
}
