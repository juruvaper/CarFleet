using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Entities
{
    public class Reservation: AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }
        public ReservationDates ReservationDates { get; private set; }
        public VIN CarIdentifier;
        public Username UserIdentifier;
        private string _startCity;
        private string _destinationCity;
        private bool _finished;

        private Reservation()
        {

        }

        private Reservation(ReservationDates reservationDates, VIN carIdentifier, Username userIdentifier, string startCity, string destinationCity, bool finished=false)
        {
            if (String.IsNullOrWhiteSpace(startCity))
            {
                throw new ArgumentException("Incorrect start city");
            }
            if (String.IsNullOrWhiteSpace(destinationCity))
            {
                throw new ArgumentException("Incorrect destination city");
            }

            ReservationDates = reservationDates;
            CarIdentifier = carIdentifier;
            UserIdentifier = userIdentifier;
            _startCity = startCity;
            _destinationCity = destinationCity;
            _finished = finished;
        }


        public void Prolongate(int days)
        {
            ReservationDates = ReservationDates.Prolongate(days);
        }

        public void Terminate()
        {
            ReservationDates = ReservationDates.Terminate();
            _finished = true;
        }

        public override string ToString()
        {
            return $"Reservation ID: {Id} | {ReservationDates} | {CarIdentifier} | Finished: {_finished} \n";
        }

        public static Reservation Create(
                                         ReservationDates reservationDates,
                                         VIN carIdentifier,
                                         Username userIdentifier,
                                         string startCity,
                                         string destinationCity,
                                         bool finished = false)
        {
            return new Reservation(reservationDates, carIdentifier, userIdentifier, startCity, destinationCity, finished);
        }
    }
}
