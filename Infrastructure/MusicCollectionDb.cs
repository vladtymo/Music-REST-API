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
            optionsBuilder.UseSqlServer("workstation id=blablashopdb.mssql.somee.com;packet size=4096;user id=wladnaz_SQLLogin_1;pwd=qsyiy5d3ff;data source=blablashopdb.mssql.somee.com;persist security info=False;initial catalog=blablashopdb");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SeedTracks();
        }

        public virtual DbSet<Track> Tracks { get; set; }
    }
}