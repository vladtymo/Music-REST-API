using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class MusicCollectionDb : DbContext
    {
        public MusicCollectionDb(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Track> Tracks { get; set; }
    }
}