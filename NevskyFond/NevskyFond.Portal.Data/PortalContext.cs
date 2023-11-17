using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NevskyFond.Portal.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Portal.Data
{
    public class PortalContext : DbContext
    {
        public PortalContext(DbContextOptions<PortalContext> options) :base(options)
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
        /// Религиозные учреждения
        /// </summary>
        public DbSet<Church> Churches => Set<Church>();

        /// <summary>
        /// Города
        /// </summary>
        public DbSet<City> Cities => Set<City>();
    }
}
