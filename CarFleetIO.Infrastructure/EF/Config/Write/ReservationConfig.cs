using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Config.Write
{
    internal sealed class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            var vinConverter = new ValueConverter<VIN, string>(s => s.Value, s => new VIN(s));
            var usernameConverter = new ValueConverter<Username, string>(u => u.Value, u => new Username(u));


            builder
               .HasKey(r => r.Id);


            builder
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();



            builder
                .Property(v => v.CarIdentifier)
                .HasConversion(vinConverter)
                .HasColumnName("CarIdentifier");

            builder
                .Property(u => u.UserIdentifier)
                .HasConversion(usernameConverter)
                .HasColumnName("UserIdentifier");

            builder.Property(typeof(string), "_startCity")
                .HasColumnName("StartCity");

            builder.Property(typeof(string), "_destinationCity")
                .HasColumnName("DestinationCity");

            builder.Property(typeof(bool), "_finished")
                .HasColumnName("Finished");


            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.UserIdentifier);


            builder
                .HasOne<Car>()
                .WithMany()
                .HasForeignKey(c => c.CarIdentifier);

            builder
                .ComplexProperty(r => r.ReservationDates);/*, owned =>
                {
                    owned.Property(sd => sd.StartDate)
                    .HasColumnType("StartDate")
                    .IsRequired();

                    owned.Property(ed => ed.EndDate)
                    .HasColumnType("EndDate")
                    .IsRequired();

                    owned.WithOwner();
                    
                });*/


        }
    }
}
