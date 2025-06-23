using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetIO.Shared.Abstractions.Queries;

namespace CarFleetIO.Application.Queries
{
    public class GetAllReservedDatesForVin: IQuery<List<string>>
    {
        public string Vin { get; set; }
    }
}
