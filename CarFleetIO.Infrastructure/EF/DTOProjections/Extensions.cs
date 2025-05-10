using CarFleetIO.Application.DTO;
using CarFleetIO.Infrastructure.EF.Models;
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
                Vin = readModel.Vin,
                LicensePlate = readModel.LicensePlate,
                Power = readModel.Power,
                Mileage = readModel.Mileage,
                User = new UserDTO
                {
                    UserId = readModel.User.UserId,
                    SecurityNumber = readModel.User.SecurityNumber,
                    OfficeId = readModel.User.OfficeId,
                    Gender = readModel.User.Gender,
                    Name = readModel.User.Name,
                    LastName = readModel.User.LastName,
                    BirthDate = readModel.User.BirthDate,
                    HireDate = readModel.User.HireDate,
                    IsActive = readModel.User.IsActive,
                },

                PrimaryLocationId = readModel.PrimaryLocationId,
                Make = readModel.Make,
                Model = readModel.Model,
                Seats = readModel.Seats,
                IsDriveable = readModel.IsDriveable,


            };

        public static UserDTO AsDto(this UserReadModel readModel)
            => new()
            {
                UserId = readModel.UserId,
                SecurityNumber = readModel.SecurityNumber,
                OfficeId = readModel.OfficeId,
                Gender = readModel.Gender,
                Name = readModel.Name,
                LastName = readModel.LastName,
                BirthDate = readModel.BirthDate,
                HireDate = readModel.HireDate,
                IsActive = readModel.IsActive,
                Cars = readModel.Cars?.Select(c => new CarDTO
                {
                    Vin = c.Vin,
                    LicensePlate = c.LicensePlate,
                    Power = c.Power,
                    Mileage = c.Mileage,
                    PrimaryLocationId = c.PrimaryLocationId,
                    Make = c.Make,
                    Model = c.Model,
                    Seats = c.Seats,
                    IsDriveable = c.IsDriveable,
                }).ToList()

            };


        public static LocalizationDTO AsDto(this LocalizationReadModel readModel)
            => new()
            {
                LocalizationId = readModel.LocalizationId,
                Country = readModel.Country,
                City = readModel.City
            };

        public static ReservationDTO AsDto(this ReservationReadModel readModel)
            => new()
            { 
                Id = readModel.Id,
                ReservationDates_StartDate = readModel.ReservationDates_StartDate,
                ReservationDates_EndDate = readModel.ReservationDates_EndDate,
                Car = new CarDTO
                {
                    Vin = readModel.Car.Vin,
                    LicensePlate = readModel.Car.LicensePlate
                },

                StartCity = readModel.StartCity,
                DestinationCity = readModel.DestinationCity,
                Finished = readModel.Finished
                
                
            };
    }

    
}
