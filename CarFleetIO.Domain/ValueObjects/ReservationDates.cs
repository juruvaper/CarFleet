using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.ValueObjects
{
    public record ReservationDates
    {
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }

        private DateOnly _tempTime;
        private int _reservationPeriod;
        
        

        public ReservationDates(DateOnly startDate, DateOnly endDate)
        {
            _tempTime = DateOnly.FromDateTime(DateTime.UtcNow);
            _reservationPeriod = (endDate.DayNumber - startDate.DayNumber);

            if (startDate >= endDate)
            {
                throw new ArgumentException("Start date cannot be greater than end date");
            }
            /*if(startDate < _tempTime || endDate < _tempTime)
            {
                throw new ArgumentException("You cannot make reservation in the past");
            }*/
            if(_reservationPeriod > 28)
            {
                throw new ArgumentException("You cannot make reservation longer than 28 days");
            }
            

            StartDate = startDate;
            EndDate = endDate;
        }

        internal ReservationDates Prolongate(int days)
        {
            if (days < 1)
            {
                throw new ArgumentException("Invalid number of days to prolong.");
            }

            var newEndDate = EndDate.AddDays(days);

            if ((newEndDate.DayNumber - StartDate.DayNumber) > 28)
            {
                throw new ArgumentException("Your reservation cannot be longer than 28 days.");
            }

            return new ReservationDates(StartDate, newEndDate);
        }

        internal ReservationDates Terminate()
        {
            return new ReservationDates(StartDate, DateOnly.FromDateTime(DateTime.UtcNow));
        }

       
        
    }
}
