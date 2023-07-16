using InitMediaContentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace InitMediaContentService.Database
{
    public class TrackContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public TrackContext() : base()
        { }
        public TrackContext(DbContextOptions<TrackContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}
