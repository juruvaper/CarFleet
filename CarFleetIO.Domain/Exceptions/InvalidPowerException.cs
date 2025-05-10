using CarFleetIO.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Exceptions
{
    public class InvalidPowerException: CarFleetIOException
    {
        public InvalidPowerException() : base("Provided power is invalid")
        {

        }
    }
}
