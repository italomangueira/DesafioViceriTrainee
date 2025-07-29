using BackHero_CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackHero_CRUD.Infrastructure
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options) { }

        public DbSet<Herois> Herois { get; set; }
        public DbSet<Superpoderes> Superpoderes { get; set; }
        public DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroisSuperpoderes>()
                .HasKey(hs => new { hs.HeroiId, hs.SuperpoderId });

            modelBuilder.Entity<HeroisSuperpoderes>()
            .HasOne(hs => hs.Herois)
            .WithMany(h => h.HeroisSuperpoderes)
            .HasForeignKey(hs => hs.HeroiId);

            modelBuilder.Entity<HeroisSuperpoderes>()
                .HasOne(hs => hs.Superpoderes)
                .WithMany(s => s.HeroisSuperpoderes)
                .HasForeignKey(hs => hs.SuperpoderId);

            modelBuilder.Entity<Herois>()
                .HasIndex(h => h.NomeHeroi)
                .IsUnique();
        }

    }
}
