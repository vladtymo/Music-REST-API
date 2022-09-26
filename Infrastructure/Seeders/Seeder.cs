using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeders
{
    internal static class Seeder
    {
        public static void SeedTracks(this ModelBuilder builder)
        {
            builder.Entity<Track>().HasData(new Track[]
            {
                new Track()
                {
                    Id = 1,
                    Name = "Yours JIN",
                    Rating = 9.1F,
                    Duration = new TimeSpan(0, 2, 45),
                    ImagePath = "images/1.jpg"
                },
                new Track()
                {
                    Id = 2,
                    Name = "Under The Influence",
                    Rating = 8.5F,
                    Duration = new TimeSpan(0, 4, 22),
                    ImagePath = "images/2.jpg"
                },
                new Track()
                {
                    Id = 3,
                    Name = "I'm Good (Blue)",
                    Rating = 8F,
                    Duration = new TimeSpan(0, 3, 49),
                    ImagePath = "images/3.jpg"
                }
            });
        }
    }
}
