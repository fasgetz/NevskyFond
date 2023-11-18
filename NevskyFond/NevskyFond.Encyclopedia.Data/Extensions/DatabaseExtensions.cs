using NevskyFond.Encyclopedia.Data.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static void MigrateAndSeed(this EncyclopediaContext dbContext)
        {
            dbContext.Database.Migrate();

            if (!dbContext.Database.GetPendingMigrations().Any())
            {
                new CitySeeder(dbContext).Seed();
                new ChurchSeeder(dbContext).Seed();
            }
        }
    }
}
