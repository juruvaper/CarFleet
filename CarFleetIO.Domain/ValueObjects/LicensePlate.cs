using CarFleetIO.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.ValueObjects
{
    public record LicensePlate
    {
        public string Value;

        public LicensePlate(string value)
        {
            if(value.Length is not (7 or 8 or 9))
            {
                throw new IncorrectLicensePlateException();
            }

            Value = value;
        }

       public static implicit operator LicensePlate(string licensePlate) =>
           new(licensePlate);

        public static implicit operator string(LicensePlate licensePlate) =>
             licensePlate.Value;
    }
}
