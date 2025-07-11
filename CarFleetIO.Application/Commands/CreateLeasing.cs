﻿using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarFleetIO.Application.Commands
{
    public record CreateLeasing(Guid LeaseId, Username personRresponsible, List<CreateCar> cars, DateOnly startDate, DateOnly endDte): ICommand_;
    

}
