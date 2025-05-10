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
    public class CreateLeasingHandler: ICommandHandler<CreateLeasing>
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarReadService _carReadService;
        private readonly ILeasingReadService _leasingReadService;
        private readonly ILeasingRepository _leasingRepository;

        public CreateLeasingHandler(ICarRepository carRepository, ICarReadService carReadService,
            ILeasingReadService leasingReadService, ILeasingRepository leasingRepository)
        {
            _carRepository = carRepository;
            _carReadService = carReadService;
            _leasingReadService = leasingReadService;
            _leasingRepository = leasingRepository;
        }


        public async Task HandleAsync(CreateLeasing command)
        {
    

            var searchLeasing = await _leasingReadService.ExistsByLeaseId(command.LeaseId);
            if(searchLeasing == null)
            {
                throw new Exception("This lease already exists");
            }
            var newLeasing = Leasing.Create(command.LeaseId, command.personRresponsible, command.startDate, command.endDte);
            await _leasingRepository.AddAsync(newLeasing);

            var leaseId = newLeasing.LeaseId;

            /*foreach (var (vin, licensePlate, power, mileage, primaryUserId, primaryLocationId, make, model, seats, fuelType, typeOfCar, year, engineSize) in command.cars)
            {
                var tempCar = Car.Create (vin, licensePlate, power, mileage, primaryUserId, primaryLocationId, make, model, seats, fuelType, typeOfCar, year, engineSize, leasedIn: leaseId);
                if (await _carReadService.ExistsByVIN(tempCar.Vin))
                {
                    throw new Exception("Car already exists outisde the leasing");
                }
      
                await _carRepository.AddAsync(tempCar);
            }
            */
            
            
            

        }
    }
}
