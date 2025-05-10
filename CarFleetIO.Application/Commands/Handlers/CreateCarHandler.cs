using CarFleetIO.Application.Services;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Commands.Handlers
{
    public sealed class CreateCarHandler: ICommandHandler<CreateCar>
    {
        private readonly ICarRepository _carrRepository;
        private readonly IUserReadService _userReadService;
        private readonly ICarReadService _carReadService;

        public CreateCarHandler(ICarRepository carRepository, IUserReadService userReadService, ICarReadService carReadService)
        {
            _userReadService = userReadService;
            _carrRepository = carRepository;
            _carReadService = carReadService;
        }

        public async Task HandleAsync(CreateCar command)
        {
            var (vin, licensePlate, primaryUserId, primaryLocationId) = command.carBasicInfo;
            var (mileage, make, model, seats, year) = command.carInfoDetails;
            var (fuelType, typeOfCar, engineSize, power) = command.carEngine; // ignore the second `power` value

            if (await _carReadService.ExistsByVIN(vin) || await _carReadService.ExistsByLicensePlate(licensePlate))
            {
                throw new ArgumentException("Car with this vin or license plate already exists!");
            }

            if(!await _userReadService.ExistsByUsername(primaryUserId))
            {
                throw new ArgumentException("Provided user doesn't exist");
            }

            var newcar = Car.Create(vin, licensePlate, power, mileage, primaryUserId, primaryLocationId, make, model, seats, fuelType, typeOfCar, year, engineSize);

            await _carrRepository.AddAsync(newcar);

        }
    }
}
