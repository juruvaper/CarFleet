using CarFleetIO.Application.Services;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http;
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
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MakeReservationHandler (IReservationRepository reservationRepository, ICarReadService carReadService, IReservationReadService reservationReadService, IUserReadService userReadService, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _reservationRepository = reservationRepository;
            _carReadService = carReadService;
            _reservationReadService = reservationReadService;
            _userReadService = userReadService;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task HandleAsync(MakeReservation command)
        {
            var (reservationDatesWriteModel, carIdentifier, startCity, destinationCity) = command;

            var reservationDates = new ReservationDates(reservationDatesWriteModel.startDate, reservationDatesWriteModel.endDate);

            var user = _httpContextAccessor.HttpContext.User;

            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }
            var name = user.Identity.Name;


            if (await _reservationReadService.ExistsByCarAndDates(carIdentifier, reservationDates.StartDate, reservationDates.EndDate))
            {
                throw new ArgumentException($"Reservation for those dates already exists for car '{carIdentifier}'. Please correct it");
            }
            
            if (!await _userReadService.ExistsByUsername(name))
            {
                throw new ArgumentException($"User '{user.Identity.Name}' does not exists");
            }
            
            
            User foundUser = await _userRepository.GetAsync(name);
            

            if (foundUser.IsActive != true)
            {
                throw new Exception("Inactive user cannot make reservations!");
            }
            if(!await _carReadService.ExistsByVIN(carIdentifier))
            {
                throw new ArgumentException($"Car '{carIdentifier}' does not exists");
            }
            

            var newReservation = Reservation.Create(reservationDates, carIdentifier, foundUser.Id, startCity, destinationCity);

            await _reservationRepository.AddAsync(newReservation);

        }
    }
}
