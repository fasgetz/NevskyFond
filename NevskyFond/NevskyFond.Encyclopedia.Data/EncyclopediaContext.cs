using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NevskyFond.Encyclopedia.Domain;

namespace NevskyFond.Encyclopedia.Data
{
    public class EncyclopediaContext : DbContext
    {
        public EncyclopediaContext(DbContextOptions<EncyclopediaContext> options) : base(options)
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
        public DbSet<Church> Churchs => Set<Church>();

        /// <summary>
        /// Города
        /// </summary>
        public DbSet<City> Cities => Set<City>();
    }
}
