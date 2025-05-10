using CarFleetIO.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.ValueObjects
{
    public record VIN
    {
        
        public VIN(string value)
        {
            if(value.Length != 17)
            {
                throw new IncorrectVINException();
            }

            Value = value;
        }

        public string Value { get; private set; }

        public static implicit operator VIN(string vin) =>
            new(vin);
        public static implicit operator string(VIN vin) =>
            vin.Value;
    }
}
