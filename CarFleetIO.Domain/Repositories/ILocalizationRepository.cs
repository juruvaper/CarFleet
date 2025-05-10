using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Repositories
{
    public interface ILocalizationRepository
    {
       
            Task<Localization> GetAsync(Guid Id);
            Task AddAsync(Localization localization);
            Task UpdateAsync(Localization localization);
            Task DeleteAsync(Localization localization);
        
    }
}
