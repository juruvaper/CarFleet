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
    internal sealed class ReservationReadConfig : IEntityTypeConfiguration<ReservationReadModel>
    {
        public void Configure(EntityTypeBuilder<ReservationReadModel> builder)
        {

            builder
                .HasKey(r => r.Id);


            builder
                .ToTable("Reservations");

            builder
                .HasOne(c => c.Car)
                .WithMany()
                .HasForeignKey(c => c.CarIdentifier);
        }
    }
}
