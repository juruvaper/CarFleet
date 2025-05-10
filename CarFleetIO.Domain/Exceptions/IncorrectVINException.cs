using CarFleetIO.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Exceptions
{
    public class IncorrectVINException: CarFleetIOException
    {
        public IncorrectVINException(): base("Invalid VIN number: it should contain exactly 17 characters")
        {

        }
    }
}
