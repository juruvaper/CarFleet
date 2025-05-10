using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Config.Write
{
    internal sealed class LeasingConfig : IEntityTypeConfiguration<Leasing>
    {
        public void Configure(EntityTypeBuilder<Leasing> builder)
        {
            var usernameConverter = new ValueConverter<Username, string>(u => u.Value, u => new Username(u));

            builder
                .HasKey(l => l.LeaseId);

            builder
                .Property(l => l.LeaseId)
                .ValueGeneratedOnAdd();

            builder
                .Property(u => u.PersonResponsibleId)
                .HasConversion(usernameConverter)
                .HasColumnName("PersonResponsibleId");

            builder.HasMany<Car>()
                .WithOne()
                .HasForeignKey(c => c.LeasedIn)
                .IsRequired(false);

            builder.HasOne<AdministrationUser>()
                .WithMany()
                .HasForeignKey(u => u.PersonResponsibleId);
                

                
        }
    }
}
