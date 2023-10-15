using Microsoft.EntityFrameworkCore;

namespace Banka
{
    public class BankaDbContext : DbContext
    {
        public BankaDbContext(DbContextOptions<BankaDbContext> options) : base(options) { }

        public DbSet<TekuciRacun> TekuciRacuni { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TekuciRacunConfigurations());
        }
    }
}
