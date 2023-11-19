using NevskyFond.SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Data.Seeders
{
    public class CommentSeeder
    {
        private readonly SocialNetworkContext _context;

        public CommentSeeder(SocialNetworkContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Comments.Any())
            {
                var churches = new List<Comment>
                {
                    new Comment() { ChurchId = 1, Text = "Комментарий средний", DateCreated = DateTime.UtcNow },
                    new Comment() { ChurchId = 1, Text = "Комментарий хороший", DateCreated = DateTime.UtcNow },
                    new Comment() { ChurchId = 1, Text = "Комментарий очень хороший", DateCreated = DateTime.UtcNow },
                    new Comment() { ChurchId = 2, Text = "Комментарий плохой", DateCreated = DateTime.UtcNow },
                    new Comment() { ChurchId = 2, Text = "Комментарий средний", DateCreated = DateTime.UtcNow },
                    new Comment() { ChurchId = 2, Text = "Комментарий хороший", DateCreated = DateTime.UtcNow },
                    new Comment() { ChurchId = 2, Text = "Комментарий очень хороший", DateCreated = DateTime.UtcNow },
                };

                _context.Comments.AddRange(churches);
                _context.SaveChanges();
            }
        }
    }
}