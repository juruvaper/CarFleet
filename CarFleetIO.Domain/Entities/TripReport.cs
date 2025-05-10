using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Entities
{
    public class TripReport: AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }
        public Guid ReservationOrigin { get; private set; }
        private int _distance;
        public List<Defect> Failures { get; private set; } = new List<Defect>();
        private float _fuelConsumed;


        private TripReport()
        {

        }

        private TripReport(Guid tripID, Guid reservationOrigin)
        {
            Id = tripID;
            ReservationOrigin = reservationOrigin;
        }


        private TripReport(Guid tripID, Guid reservationOrigin, int distance, float fuelConsumed)
        {
            if(distance < 1 || distance > 9999)
            {
                throw new ArgumentException("Invalid distance");
            }

            if(fuelConsumed < 1 || fuelConsumed > 500)
            {
                throw new ArgumentException("Invalid fuel consumption");
            }


            Id = tripID;
            ReservationOrigin = reservationOrigin;
            _distance = distance;
            _fuelConsumed = fuelConsumed;
        }

        public static TripReport Create(Guid tripID, Guid reservationOrigin)
        {
            return new TripReport(tripID, reservationOrigin);
;        }


        public void FillTripInfo(int distance, float fuelConsumed)
        {
            this._distance = distance;
            this._fuelConsumed = fuelConsumed;
        }

        public void AddFailures(Defect defect)
        {
            if(Failures.Any(f => f.Description == defect.Description))
            {
                throw new ArgumentException("The same failure has been already reported");
            }

            Failures.Add(defect);
        } 

        public float CalculateMPG()
        {
            return _fuelConsumed / _distance;
        }

        public override string ToString()
        {
            return $"Trip ID: {Id} | Reservation Origin: {ReservationOrigin} | Distance: {_distance}";
        }

        public string ShowFailures()
        {
            if (Failures.Count == 0)
                return "No failures reported.";

            var builder = new StringBuilder();
            foreach (var fail in Failures)
            {
                builder.AppendLine($"- {fail.Description} (Severity: {fail._severity}, Car stop: {fail._carStop})");
            }

            return builder.ToString();
        }
    }
}
