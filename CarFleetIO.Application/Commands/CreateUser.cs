using CarFleetIO.Domain.Consts;
using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarFleetIO.Application.Commands
{
    public record CreateUser(
            CustomerNameWriteModel name, CustomerDatesWriteModel dates, CustomerDetailsWriteModel details): ICommand_
    {
    }

    public record CustomerNameWriteModel(string name, string lastName);
    public record CustomerDetailsWriteModel(string userID, long securityNumber, Guid office, Gender gender, bool isActive);
    public record CustomerDatesWriteModel(DateOnly birth, DateOnly hire);
}
