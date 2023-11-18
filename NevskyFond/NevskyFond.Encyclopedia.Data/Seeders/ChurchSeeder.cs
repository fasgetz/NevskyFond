using NevskyFond.Encyclopedia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Data.Seeders
{
    public class ChurchSeeder
    {
        private readonly EncyclopediaContext _context;

        public ChurchSeeder(EncyclopediaContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Churchs.Any())
            {
                var churches = new List<Church>
                {
                    new Church() { CityId = 1, Name = "Храм Василия Блаженного", DateCreation = DateTime.Now },
                    new Church() { CityId = 1, Name = "Храм Христа Спасителя", DateCreation = DateTime.Now },
                    new Church() { CityId = 1, Name = "Храм Покрова Пресвятой Богородицы", DateCreation = DateTime.Now }
                };

                _context.churches.AddRange(churches);
                _context.SaveChanges();
            }
        }
    }
}