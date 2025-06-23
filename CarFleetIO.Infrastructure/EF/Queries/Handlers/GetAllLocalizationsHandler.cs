using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.DTOProjections;
using CarFleetIO.Infrastructure.EF.Models;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CarFleetIO.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllLocalizationsHandler: IQueryHandler<GetAllLocalizations, ICollection<LocalizationDTO>>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly DbSet<LocalizationReadModel> _localizations;

        public GetAllLocalizationsHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
            _localizations = _readDbContext.Localizations;
        }

        public async Task<ICollection<LocalizationDTO>> HandleAsync(GetAllLocalizations query)
        {
            return await _localizations.Select(p => p.AsDto()).AsNoTracking().ToListAsync();
        }
    }
}
