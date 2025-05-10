using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Shared.Abstractions.Exceptions
{
    public abstract class CarFleetIOException: Exception
    {
        protected CarFleetIOException(string message): base(message)
        {

        }
    }
}
