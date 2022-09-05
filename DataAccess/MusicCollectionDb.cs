using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MusicCollectionDb : DbContext
    {
        public MusicCollectionDb(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Track> Tracks { get; set; }
    }
}