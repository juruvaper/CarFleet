using CarFleetIO.Application.Services;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Commands.Handlers
{
    public class FinishReservationHandler: ICommandHandler<FinishReservation>
    {
        private readonly IReservationReadService _reservationReadService;
        private readonly IReservationRepository _reservationRepository;
        private readonly ITripReportRepository _tripReportRepository;

        public FinishReservationHandler(IReservationReadService reservationReadService, IReservationRepository reservationRepository,
            ITripReportRepository tripReportRepository)
        {
            _reservationReadService = reservationReadService;
            _reservationRepository = reservationRepository;
            _tripReportRepository = tripReportRepository;
        }

        public async Task HandleAsync(FinishReservation command)
        {

            var reservation = await _reservationRepository.GetAsync(command.reservationId);

            if(reservation == null)
            {
                throw new Exception($"Reservation '{reservation.Id}' cannot be found");
            }

            reservation.Terminate();
            var newTripReport = TripReport.Create(reservation.Id, Guid.NewGuid());

            await _reservationRepository.UpdateAsync(reservation);
            await _tripReportRepository.AddAsync(newTripReport);




        }
    }
}
