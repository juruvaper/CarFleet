using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarFleetIO.Shared.Abstractions.Commands;

namespace CarFleetIO.Infrastructure.EF.Identity
{
    public record RegisterUser(string username, string email, string password): ICommand_
    {
    }
}
