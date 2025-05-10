using CarFleetIO.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Exceptions
{
    public class UserAlreadyExistsException: CarFleetIOException
    {
        public UserAlreadyExistsException() : base("User with this username or security number already exists")
        {

        }
    }
}
