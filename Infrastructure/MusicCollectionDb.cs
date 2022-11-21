using Core.Entities;
using Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    internal class MusicCollectionDb : IdentityDbContext
    {
        public MusicCollectionDb()
        {

        }
        public MusicCollectionDb(DbContextOptions options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:myserver4343.database.windows.net,1433;Initial Catalog=musicAzureDb;Persist Security Info=False;User ID=super_user;Password=Abc123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SeedTracks();
        }

        public virtual DbSet<Track> Tracks { get; set; }
    }
}