using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetIO.Application.DTO;
using CarFleetIO.Shared.Abstractions.Queries;

namespace CarFleetIO.Application.Queries
{
    public class GetAllLocalizations: IQuery<ICollection<LocalizationDTO>>
    {
    }
}
