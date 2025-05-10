using CarFleetIO.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Exceptions
{
    public class EmptyLastNameException: CarFleetIOException
    {
        public EmptyLastNameException(): base("Incorrect last name")
        {

        }
    }
}
