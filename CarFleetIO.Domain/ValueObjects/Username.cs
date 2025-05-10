using CarFleetIO.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.ValueObjects
{
    public record Username
    {
        public Username(string value)
        {
            if (String.IsNullOrWhiteSpace(value) || value.Length != 6)
            {
                throw new IncorrectUsernameException();
            }

            Value = value;
        }

        public string Value { get; private set; }

        
        public static implicit operator Username(string username)
            => new(username);
        public static implicit operator string(Username usn)
            => usn.Value;
        

    }


}
