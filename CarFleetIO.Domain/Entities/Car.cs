using CarFleetIO.Domain.Consts;
using CarFleetIO.Domain.Exceptions;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Entities
{
    public class Car
    {
        public VIN Vin { get; private set; }

        public LicensePlate LicensePlate;
     
        public Username PrimaryUserId { get; private set; }
        //public User User { get; private set; }

        public Guid PrimaryLocationId { get; private set; }
        private int _power;
        public float EngineSize { get; private set; }
        //dodac settera 
        private int _mileage;
        public FuelType Fuel { get; private set; }
        public TypeOfCar Type { get; private set; }
        public int Year { get; private set; }
        private string _make;
        private string _model;
        private int _seats;
        public bool IsDriveable;
        public Guid? LeasedIn { get; private set; }

        private Car(VIN vin, LicensePlate licensePlate, int power, int mileage, Username primaryUserId,
            Guid primaryLocationId, string make, string model, int seats, FuelType fuelType, TypeOfCar typeOfCar, int year, float engineSize, bool isDriveable = true, Guid? leasedIn = null)
        {
            

            if (mileage < 1 || mileage > 999999)
            {
                throw new ArgumentException(nameof(mileage));
            }
            if (string.IsNullOrWhiteSpace(make))
            {
                throw new ArgumentException(nameof(make));
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException(nameof(model));
            }
            if (seats < 2 || seats > 9)
            {
                throw new ArgumentException(nameof(seats));
            }
            if(engineSize < 0.9 || engineSize > 6.2)
            {
                throw new ArgumentException("Engine size must be between 0.9 and 6.2");
            }
            if(year < 1970 || year > 2025)
            {
                throw new ArgumentException("Invalid year. Please provide a value between 1970 and 2025");
            }
            if (power < 30 || power > 800)
            {
                throw new InvalidPowerException();
            }


            Vin = vin;
            LicensePlate = licensePlate;
            _power = power;
            _mileage = mileage;
            PrimaryUserId = primaryUserId;
            PrimaryLocationId = primaryLocationId;
            _make = make;
            _model = model;
            _seats = seats;
            IsDriveable = isDriveable;
            LeasedIn = leasedIn;
            Fuel = fuelType;
            Type = typeOfCar;
            EngineSize = engineSize;
            Year = year;
            _power = power;
            
        }

        private Car()
        {

        }

        public static Car Create(VIN vin, LicensePlate licensePlate, int power, int mileage, Username primaryUserId,
            Guid primaryLocationId, string make, string model, int seats, FuelType fuelType, TypeOfCar typeOfCar, int year, float engineSize, bool isDriveable = true, Guid? leasedIn = null)
        {
            //var car = new Car();

            //car.SetPower(power);

            return new Car(vin, licensePlate, power, mileage, primaryUserId, primaryLocationId, make, model, seats, fuelType, typeOfCar, year, engineSize, isDriveable, leasedIn);
            
        }

        /*public void SetPower(int power)
        {
            if (power < 30 || power > 800)
            {
                throw new InvalidPowerException();
            }

            _power = power;
        }
        */
    }
}
