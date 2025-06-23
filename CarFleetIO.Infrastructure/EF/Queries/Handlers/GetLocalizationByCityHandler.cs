using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.DTOProjections;
using CarFleetIO.Infrastructure.EF.Models;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http;
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
        private IHttpContextAccessor _httpContextAccessor;

        public GetLocalizationByCityHandler(ReadDbContext readDbContext, IHttpContextAccessor httpContextAccesso)
        {
            _localizations = readDbContext.Localizations;
            _httpContextAccessor = httpContextAccesso;
        }

        public async Task<LocalizationDTO> HandleAsync(GetLocalizationByCity query)
        {
            var u = _httpContextAccessor.HttpContext.User;

            return await _localizations.Where(l => l.City == query.City).
                Select(l => l.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
    }
}
