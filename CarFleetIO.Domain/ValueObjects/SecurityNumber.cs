using CarFleetIO.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.ValueObjects
{
    public record SecurityNumber
    {
        public long _number;

        public SecurityNumber(long number)
        {
            if(number.ToString().Length != 11)
            {
                throw new IncorrectSecurityNumberException();
            }

            _number = number;
        }

        public static implicit operator long(SecurityNumber securityNumber)
            => securityNumber._number;

        public static implicit operator SecurityNumber(long securityNumber)
            => new(securityNumber);
        
    }
}
