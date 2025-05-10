using CarFleetIO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Config.Write
{
    internal sealed class TripReportConfig : IEntityTypeConfiguration<TripReport>
    {
        public void Configure(EntityTypeBuilder<TripReport> builder)
        {
            builder.
                HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
                


            builder
                .Property(typeof(int), "_distance")
                .HasColumnName("Distance");

            builder
                .Property(typeof(float), "_fuelConsumed")
                .HasColumnName("FuelConsumed");

            builder
                .OwnsMany(f => f.Failures, cb =>
                {
                    cb.WithOwner().HasForeignKey("TripReportId");

                    cb.Property<int>("Id"); //shadow prop

                    cb.HasKey("Id");

                    cb.Property(d => d.Description).IsRequired();

                    cb.Property(s => s._severity)
                    .HasColumnName("Severity");

                    cb.Property(cs => cs._carStop)
                    .HasColumnName("CarStop");

                });

            builder
                .HasOne<Reservation>()
                .WithMany()
                .HasForeignKey(r => r.ReservationOrigin);
                
        }
    }
}
