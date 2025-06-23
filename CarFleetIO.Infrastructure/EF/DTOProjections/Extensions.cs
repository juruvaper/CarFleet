using CarFleetIO.Application.DTO;
using CarFleetIO.Infrastructure.EF.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.DTOProjections
{
    internal static class Extensions
    {
        public static CarDTO AsDto(this CarReadModel readModel)
            => new()
            {
                Vin = readModel.VIN,
                LicensePlate = readModel.LicensePlate,
                Power = readModel.Power,
                Mileage = readModel.Mileage,
                Year = readModel.Year,
                User = new UserDTO
                {
                    UserId = readModel.User.UserId,
                    //SecurityNumber = readModel.User.SecurityNumber,
                    Office = readModel.User.Office,
                    //Gender = readModel.User.Gender,
                    Name = readModel.User.Name,
                    LastName = readModel.User.LastName,
                    //BirthDate = readModel.User.BirthDate,
                    //HireDate = readModel.User.HireDate,
                    //IsActive = readModel.User.IsActive,
                },

                PrimaryLocationId = readModel.PrimaryLocationId,
                Make = readModel.Make,
                Model = readModel.Model,
                Seats = readModel.Seats,
                IsDriveable = readModel.IsDriveable,
                Fuel = readModel.Fuel


            };

        public static UserDTO AsDto(this UserReadModel readModel)
            => new()
            {
                UserId = readModel.UserId,
                SecurityNumber = readModel.SecurityNumber,
                Office = readModel.Office,
                Gender = readModel.Gender,
                Name = readModel.Name,
                LastName = readModel.LastName,
                BirthDate = readModel.BirthDate,
                HireDate = readModel.HireDate,
                IsActive = readModel.IsActive,
                Cars = readModel.Cars?.Select(c => new CarDTO
                {
                    Vin = c.VIN,
                    LicensePlate = c.LicensePlate,
                    Power = c.Power,
                    Mileage = c.Mileage,
                    PrimaryLocationId = c.PrimaryLocationId,
                    Make = c.Make,
                    Model = c.Model,
                    Seats = c.Seats,
                    IsDriveable = c.IsDriveable,
                    Fuel = c.Fuel
                }).ToList()

            };


        public static ReservationDTO AsDto(this ReservationReadModel readModel)
            => new()
            { 
                Id = readModel.Id,
                ReservationDates_StartDate = readModel.ReservationDates_StartDate,
                ReservationDates_EndDate = readModel.ReservationDates_EndDate,
                Car = new CarDTO
                {
                    Vin = readModel.Car.VIN,
                    LicensePlate = readModel.Car.LicensePlate
                },

                StartCity = readModel.StartCity,
                DestinationCity = readModel.DestinationCity,
                Finished = readModel.Finished
                
                
            };

        public static LocalizationDTO AsDto(this LocalizationReadModel readModel)
            => new()
            {
                LocalizationId = readModel.LocalizationId,
                Country = readModel.Country,
                City = readModel.City,
            };
    }

    
}
