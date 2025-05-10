using CarFleetIO.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Exceptions
{
    public class IncorrectBirthDateException: CarFleetIOException
    {
        public IncorrectBirthDateException() : base("Birth date from future or greater than 1920")
        {

        }
    }
}
