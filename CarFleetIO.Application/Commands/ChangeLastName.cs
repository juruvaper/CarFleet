﻿using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarFleetIO.Application.Commands
{
    public record ChangeLastName (string username, string newLastName): ICommand_;
    
}
