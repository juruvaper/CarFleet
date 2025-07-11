﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Models
{
    internal class CarReadModel
    {
        public string Vin { get; set; }
        public string LicensePlate { get; set; }
        public int Power { get; set; }
        public int Mileage { get; set; }
        public string PrimaryUserId { get; set; }
        public Guid PrimaryLocationId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Seats { get; set; }
        public bool IsDriveable { get; set; }

        //Navigation properties

        public virtual UserReadModel User { get; set; }

    }
}
