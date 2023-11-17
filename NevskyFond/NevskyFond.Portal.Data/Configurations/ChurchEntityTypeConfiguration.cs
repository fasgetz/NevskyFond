using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NevskyFond.Portal.Domain;

namespace NevskyFond.Portal.Data.Configurations
{
    public class ChurchEntityTypeConfiguration : IEntityTypeConfiguration<Church>
    {
        public void Configure(EntityTypeBuilder<Church> builder)
        {
            builder.ToTable("Churches");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasOne(e => e.City)
                .WithMany(e => e.Churches)
                .HasForeignKey(e => e.CityId);
        }
    }
}
