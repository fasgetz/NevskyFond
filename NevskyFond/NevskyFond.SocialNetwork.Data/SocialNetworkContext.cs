using Microsoft.EntityFrameworkCore;
using NevskyFond.SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Data
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options) : base(options)
        {

        }

        /// <summary>
        /// Применить конфигурации
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Комментарии религиозных учреждений
        /// </summary>
        public DbSet<Comment> Comments => Set<Comment>();
    }
}
