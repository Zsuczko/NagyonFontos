using CinemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemApi.Data
{
    public class FilmDbContext: DbContext
    {
        public FilmDbContext(DbContextOptions<FilmDbContext> options): base(options) { }

        public DbSet<Film> Films { get; set; }
        public DbSet<Rendezo> Rendezos { get; set; }
        public DbSet<Vetites> Vetitesek { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>().HasOne(x => x.Rendezo).WithMany(x => x.Films).HasForeignKey(x => x.RendezoId);
            modelBuilder.Entity<Vetites>().HasOne(x => x.Film).WithMany(x => x.Vetitess).HasForeignKey(x => x.FilmId);
        }
    }
}
