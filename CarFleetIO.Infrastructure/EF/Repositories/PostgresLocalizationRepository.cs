using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Repositories
{



    internal sealed class PostgresLocalizationRepository : ILocalizationRepository
    {

        private readonly WriteDbContext _dbContext;
        private readonly DbSet<Localization> _localizations;

        public PostgresLocalizationRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
            _localizations = dbContext.Localizations;
        }

        public async Task AddAsync(Localization localization)
        {
            _localizations.Add(localization);
            await _dbContext.SaveChangesAsync();
            
        }

        public Task DeleteAsync(Localization localization)
        {
            throw new NotImplementedException();
        }

        public Task<Localization> GetAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Localization localization)
        {
            throw new NotImplementedException();
        }
    }
}
