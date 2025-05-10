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
    internal sealed class LocalizationConfig : IEntityTypeConfiguration<Localization>
    {
        public void Configure(EntityTypeBuilder<Localization> builder)
        {
            builder.HasKey(l => l.LocalizationID);

            builder.Property(l => l.LocalizationID)
                .ValueGeneratedOnAdd()
                .HasColumnName("LocalizationId");

            builder.Property(typeof(string), "_city")
                .HasColumnName("City");

            builder.Property(typeof(string), "_country")
                .HasColumnName("Country");

            builder.HasData(Localization.Seed(Guid.Parse("3f5a8f1e-2b3c-4a6d-9e2f-7d3b2c1a5f01"), "New York", "USA"),
                            Localization.Seed(Guid.Parse("d9a6e7b4-1c3d-42f5-a8b7-9c3d2f5a6e12"), "Los Angeles", "USA"),
                            Localization.Seed(Guid.Parse("b2d3e5f6-78c9-41e2-91a3-3a5c1e2d4f83"), "Chicago", "USA"),
                            Localization.Seed(Guid.Parse("a5e3c1b2-6f79-4d8e-a1c4-5f2e3b7a9d74"), "Miami", "USA"),
                            Localization.Seed(Guid.Parse("e2f5a6c3-9d1b-4e3f-81a7-7b6d4c2f1a95"), "San Francisco", "USA"),
                            Localization.Seed(Guid.Parse("91a7d6c3-2f1b-4e5c-a3d2-8c7b6a5f4e03"), "London", "UK"),
                            Localization.Seed(Guid.Parse("7c9b5a3e-d2f1-41e6-9a3c-2b4d5f6a8e16"), "Manchester", "UK"),
                            Localization.Seed(Guid.Parse("6a5d4c3b-1f9e-44a7-82d3-5e4f1c2b7a19"), "Birmingham", "UK"),
                            Localization.Seed(Guid.Parse("5f2e3d1b-9a7c-4c8e-b6d2-1a3f4e7b5c28"), "Sydney", "Australia"),
                            Localization.Seed(Guid.Parse("c3d2e1f4-7b5a-4a6c-9d8e-2f1b3a5c6e37"), "Melbourne", "Australia"),
                            Localization.Seed(Guid.Parse("2e4f1b3d-8a7c-43c6-9e1f-5a6b7d2c1a46"), "Paris", "France"),
                            Localization.Seed(Guid.Parse("8f1e3a7b-2d4c-4c9a-8e6d-3f5b1a2c7e55"), "Berlin", "Germany"),
                            Localization.Seed(Guid.Parse("1b3d5a6f-7e4c-44d9-a2b1-6c3f8e7a9d64"), "Madrid", "Spain"),
                            Localization.Seed(Guid.Parse("4e7b6d2c-3a1f-49e8-b5a2-7c8d9e1f3a73"), "Rome", "Italy"),
                            Localization.Seed(Guid.Parse("9e1f3a6d-5b2c-43d8-8a7c-1b6f4e5a7c82"), "Toronto", "Canada"));


        }
    }
}
