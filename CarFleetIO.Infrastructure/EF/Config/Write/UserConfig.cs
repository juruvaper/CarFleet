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
    internal sealed class UserConfig: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var usernameConverter = new ValueConverter<Username, string>(
         u => u == null ? null : u.Value,
         u => u == null ? null : new Username(u));

            var securityNumberConverter = new ValueConverter<SecurityNumber?, long?>(
            u => u == null ? (long?)null : u._number,
            u => u == null ? null : new SecurityNumber(u.Value)
            );

            var genderConverter = new EnumToStringConverter<Gender>();


            builder
                .Property(u => u.Id)
                .HasConversion(usernameConverter)
                .HasColumnName("Username");

            builder
                .Property(u => u.IdentityId);

            builder
                .Property(s => s.SecurityNumber)
                .HasConversion(securityNumberConverter)
                .HasColumnName("SecurityNumber");



            builder
                .Property(typeof(Gender?), "_gender")
                .HasConversion(genderConverter)
                .HasColumnName("Gender");



            builder
                .Property(typeof(string), "_name")
                .HasColumnName("Name");


            builder
                .Property(typeof(string), "_lastName")
                .HasColumnName("LastName");


            builder
                .Property(typeof(DateOnly?), "_birthDate")
                .HasColumnName("BirthDate");


            builder
               .Property(typeof(DateOnly?), "_hireDate")
               .HasColumnName("HireDate");


            builder
                .Property(a => a.IsActive)
                .HasColumnName("IsActive");
                

            builder
                .HasOne<Localization>()
                .WithMany()
                .HasForeignKey(o => o.Office);
        }
    }
}
