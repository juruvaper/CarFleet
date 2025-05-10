using CarFleetIO.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Exceptions
{
    public class IncorrectSecurityNumberException: CarFleetIOException
    {
        public IncorrectSecurityNumberException(): base("Security number must be exactly 11 numbers")
        {

        }
    }
}
