using CarFleetIO.Domain.Consts;
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
    public record CreateCar(CarBasicInfoWriteModel carBasicInfo, CarDetailsWriteModel carInfoDetails, CarEngineWriteModel carEngine) : ICommand_
    {
    }

    public record CarDetailsWriteModel(int mileage, string make, string model, int seats, int year);
    public record CarBasicInfoWriteModel(string vin, string licenseplate, string primaryUserId, Guid primaryLocationId);
    public record CarEngineWriteModel(FuelType fuelType, TypeOfCar typeOfcar, float engineSize, int power);

}
    
        
    

