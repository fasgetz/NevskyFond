using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NevskyFond.SocialNetwork.Domain;

namespace NevskyFond.SocialNetwork.Data.Configurations
{
    public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.ChurchId)
                .IsClustered(false);
        }
    }
}