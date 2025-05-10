using CarFleetIO.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Config.Read
{
    internal sealed class UserReadConfig : IEntityTypeConfiguration<UserReadModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserReadModel> builder)
        {

            builder
                .ToTable("Users");

            builder
                .HasKey(u => u.UserId);

            builder
                .Property(u => u.UserId)
                .HasColumnName("Username");


            builder
                .HasMany(c => c.Cars)
                .WithOne(u => u.User)
                .HasForeignKey(c => c.PrimaryUserId);
        }
    }
}
