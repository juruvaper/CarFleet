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
    internal sealed class CarReadConfig : IEntityTypeConfiguration<CarReadModel>
    {
        public void Configure(EntityTypeBuilder<CarReadModel> builder)
        {
            builder
                .ToTable("Cars");

            builder
                .HasKey(v => v.VIN);

            builder
                .Property(v => v.VIN)
                .HasColumnName("VIN");

            builder
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.PrimaryUserId);


        }
    }
}
