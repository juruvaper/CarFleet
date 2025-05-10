using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarFleetIO.Application.Commands
{
    public record FillTripDetails: ICommand_
    {
        public Guid TripID;
        public int _distance { get;private set; }
        public float _fuelConsumed { get; private set; }

        public FillTripDetails(Guid tripID, int distance, float fuelConsumed)
        {
            _distance = distance;
            _fuelConsumed = fuelConsumed;
            TripID = tripID;
        }
    }
}
