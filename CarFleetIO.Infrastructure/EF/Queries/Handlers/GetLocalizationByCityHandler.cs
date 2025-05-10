using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.DTOProjections;
using CarFleetIO.Infrastructure.EF.Models;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetLocalizationByCityHandler: IQueryHandler<GetLocalizationByCity, LocalizationDTO>
    {
        public DbSet<LocalizationReadModel> _localizations;

        public GetLocalizationByCityHandler(ReadDbContext readDbContext)
        {
            _localizations = readDbContext.Localizations;
        }

        public async Task<LocalizationDTO> HandleAsync(GetLocalizationByCity query)
        {
            return await _localizations.Where(l => l.City == query.City).
                Select(l => l.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
    }
}
