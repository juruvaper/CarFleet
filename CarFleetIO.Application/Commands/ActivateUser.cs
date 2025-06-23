using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetIO.Shared.Abstractions.Commands;

namespace CarFleetIO.Application.Commands
{
    public record ActivateUser (string username): ICommand_
    {
    }
}
