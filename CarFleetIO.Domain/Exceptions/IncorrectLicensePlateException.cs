using CarFleetIO.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Exceptions
{
    public class IncorrectLicensePlateException: CarFleetIOException
    {
        public IncorrectLicensePlateException(): base("License plate should contain" +
            "exactly 7, 8 or 9 numbers")
        {

        }
    }
}
