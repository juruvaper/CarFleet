using CarFleetIO.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Exceptions
{
    public class EmptyFirstNameException: CarFleetIOException
    {
        public EmptyFirstNameException(): base("First name is incorrect")
        {

        }
    }
}
