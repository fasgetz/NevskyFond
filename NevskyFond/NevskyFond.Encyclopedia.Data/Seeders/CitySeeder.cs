using NevskyFond.Encyclopedia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Data.Seeders
{
    public class CitySeeder
    {
        private readonly EncyclopediaContext _context;

        public CitySeeder(EncyclopediaContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Churchs.Any())
            {
                var cities = new List<City>
                {
                    new City() { Name = "Москва" },
                };

                _context.Cities.AddRange(cities);
                _context.SaveChanges();
            }
        }
    }
}
