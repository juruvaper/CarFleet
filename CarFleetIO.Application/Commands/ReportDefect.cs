using CarFleetIO.Domain.Consts;
using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarFleetIO.Application.Commands
{
      public record ReportDefect(string description, Severity severity, bool carStop);
  
      public record Failures(Guid tripIdOrigin, List<ReportDefect> failures): ICommand_;

      
    }

