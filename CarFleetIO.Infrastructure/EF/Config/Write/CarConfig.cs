using CarFleetIO.Domain.Consts;
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
    internal sealed class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {

            var licensePlateConverter = new ValueConverter<LicensePlate, string>(l => l.Value, l => new LicensePlate(l));
            var usernameConverter = new ValueConverter<Username, string>(u => u.Value, u => new Username(u));
            var vinConverter = new ValueConverter<VIN, string>(v => v.Value, v => new VIN(v));

            builder.Property(v => v.Vin)
                .HasConversion(vinConverter)
                .IsRequired()
                .HasColumnName("VIN");


            builder.HasKey(v => v.Vin);


            builder
            .Property(c => c.PrimaryUserId)
            .HasConversion(usernameConverter)
            .HasColumnName("PrimaryUserId");


            builder
                .Property(li => li.LicensePlate)
                .HasConversion(licensePlateConverter)
                .HasColumnName("LicensePlate");

            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.PrimaryUserId);


            builder
                .HasOne<Localization>()
                .WithMany()
                .HasForeignKey(l => l.PrimaryLocationId);


            builder
                .Property(typeof(int), "_power")
                .HasColumnName("Power");

            builder
                .Property(typeof(int), "_mileage")
                .HasColumnName("Mileage");

            builder
                .Property(l => l.PrimaryLocationId)
                .HasColumnName("PrimaryLocationId");

            builder
                .Property(typeof(string), "_make")
                .HasColumnName("Make");

            builder
                .Property(typeof(string), "_model")
                .HasColumnName("Model");

            builder
                .Property(typeof(int), "_seats")
                .HasColumnName("Seats");

            builder
                .Property(d => d.IsDriveable)
                .HasColumnName("IsDriveable");


            builder
                .ToTable("Cars");


        }

    }
}
