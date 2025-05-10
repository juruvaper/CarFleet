using CarFleetIO.Application.Services;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarFleetIO.Application.Commands.Handlers
{
    public class MakeReservationHandler : ICommandHandler<MakeReservation>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICarReadService _carReadService;
        private readonly IReservationReadService _reservationReadService;
        private readonly IUserReadService _userReadService;

        public MakeReservationHandler (IReservationRepository reservationRepository, ICarReadService carReadService, IReservationReadService reservationReadService, IUserReadService userReadService)
        {
            _reservationRepository = reservationRepository;
            _carReadService = carReadService;
            _reservationReadService = reservationReadService;
            _userReadService = userReadService;
        }


        public async Task HandleAsync(MakeReservation command)
        {
            var (reservationDatesWriteModel, carIdentifier, userIdentifier, startCity, destinationCity) = command;

            var reservationDates = new ReservationDates(reservationDatesWriteModel.startDate, reservationDatesWriteModel.endDate);

            if(await _reservationReadService.ExistsByCarAndDates(carIdentifier, reservationDates.StartDate, reservationDates.EndDate))
            {
                throw new ArgumentException($"Reservation for those dates already exists for car '{carIdentifier}'. Please correct it");
            }

            if(!await _userReadService.ExistsByUsername(userIdentifier))
            {
                throw new ArgumentException($"User '{userIdentifier}' does not exists");
            }

            if(!await _carReadService.ExistsByVIN(carIdentifier))
            {
                throw new ArgumentException($"Car '{carIdentifier}' does not exists");
            }

            var newReservation = Reservation.Create(reservationDates, carIdentifier, userIdentifier, startCity, destinationCity);

            await _reservationRepository.AddAsync(newReservation);

        }
    }
}
