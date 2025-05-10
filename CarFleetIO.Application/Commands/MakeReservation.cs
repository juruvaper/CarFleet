using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarFleetIO.Application.Commands
{
    public record MakeReservation(ReservationDatesWriteModel reservationDatesWriteModel, string carIdentifier, string userIdentifier, string startCity, string destinationCity): ICommand_
    {
    }

    public record ReservationDatesWriteModel(DateOnly startDate, DateOnly endDate);
}
