using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NevskyFond.Encyclopedia.Domain;

namespace NevskyFond.Encyclopedia.Data.Configurations
{
    public class ChurchEntityTypeConfiguration : IEntityTypeConfiguration<Church>
    {
        public void Configure(EntityTypeBuilder<Church> builder)
        {
            builder.ToTable("Churchs");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasOne(e => e.City)
                .WithMany(e => e.Churchs)
                .HasForeignKey(e => e.CityId);
        }
    }
}
