﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NevskyFond.Encyclopedia.Domain;

namespace NevskyFond.Encyclopedia.Data.Configurations
{
    public class CityEntityTypeConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
