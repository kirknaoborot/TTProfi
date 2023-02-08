using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TTProfi.Data.Domain;

namespace TTProfi.Data
{
    public class TTContext : DbContext
    {
        public TTContext(DbContextOptions<TTContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Player> Players { get; set; }
        
        public DbSet<Service> Services { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<TournamentType> TournamentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasKey(_ => _.Id);
            modelBuilder.Entity<Player>().HasMany(_ => _.Tournaments).WithMany(_ => _.Players).UsingEntity(j => j.ToTable("PLAYER_TOURNAMENT"));

            modelBuilder.Entity<Service>().HasKey(_ => _.Id);

            modelBuilder.Entity<Tournament>().HasKey(_ => _.Id);
            modelBuilder.Entity<Tournament>().HasOne(_ => _.TournamentType).WithMany(_ => _.Tournaments).HasForeignKey(_ => _.TournamentTypeId);

            modelBuilder.Entity<TournamentType>().HasKey(_ => _.Id);
        }
    }
}
