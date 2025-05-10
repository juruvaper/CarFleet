using CarFleetIO.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Config.Read
{
    internal sealed class LocalizationReadConfig : IEntityTypeConfiguration<LocalizationReadModel>
    {
        public void Configure(EntityTypeBuilder<LocalizationReadModel> builder)
        {
            builder
                .ToTable("Localizations");

            builder
                .HasKey(l => l.LocalizationId);
        }
    }
}
