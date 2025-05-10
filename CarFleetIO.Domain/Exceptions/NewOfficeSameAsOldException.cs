using CarFleetIO.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Exceptions
{
    public class NewOfficeSameAsOldException: CarFleetIOException
    {
        public NewOfficeSameAsOldException() : base("Provided office is the same as the old one - no changes will take place")
        {

        }
    }
}
