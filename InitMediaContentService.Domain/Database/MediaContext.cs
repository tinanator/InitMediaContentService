using InitMediaContentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InitMediaContentService.Database
{
    public class MediaContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public MediaContext() : base()
        { }
        public MediaContext(DbContextOptions<MediaContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}
