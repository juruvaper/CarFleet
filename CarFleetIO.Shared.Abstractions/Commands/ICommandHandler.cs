using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Shared.Abstractions.Commands
{
    public interface ICommandHandler <in TCommand> where TCommand : class, ICommand_
    {
        Task HandleAsync(TCommand command);
    }
}
