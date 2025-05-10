using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.DTO
{
    public class CarDTO
    {
        public string Vin;
        public string LicensePlate;
        public int Power;
        public int Mileage;
        public UserDTO User;
        public Guid PrimaryLocationId;
        public string Make;
        public string Model;
        public int Seats;
        public bool IsDriveable;

    }
}
