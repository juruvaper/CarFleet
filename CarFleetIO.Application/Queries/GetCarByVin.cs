using CarFleetIO.Application.DTO;
using CarFleetIO.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Queries
{
    public class GetCarByVin: IQuery<CarDTO>
    {
        public string Vin {  get; set; }
    }
}
