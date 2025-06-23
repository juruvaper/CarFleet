using System;

namespace CarFleetIO.Application.DTO
{
    public class CarDTO
    {
        public string Vin { get; set; }
        public string LicensePlate { get; set; }
        public int Power { get; set; }
        public int Mileage { get; set; }
        public int Year { get; set; }
        public UserDTO User { get; set; }
        public Guid PrimaryLocationId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Seats { get; set; }
        public bool IsDriveable { get; set; }
        public int Fuel { get; set; }
    }
}
