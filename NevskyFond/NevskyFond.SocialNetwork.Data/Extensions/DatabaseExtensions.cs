using Microsoft.EntityFrameworkCore;
using NevskyFond.SocialNetwork.Data.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static void MigrateAndSeed(this SocialNetworkContext dbContext)
        {
            dbContext.Database.Migrate();

            if (!dbContext.Database.GetPendingMigrations().Any())
            {
                new CommentSeeder(dbContext).Seed();
            }
        }
    }
}