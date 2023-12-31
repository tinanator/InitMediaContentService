﻿using InitMediaContentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace InitMediaContentService.Database
{
    public class MediaContext : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Release> Release { get; set; }
        public DbSet<Track> Track { get; set; }
        public MediaContext() : base()
        { }
        public MediaContext(DbContextOptions<MediaContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .ToTable("Artist")
                .HasKey(x => x.ClusterId)
                .HasName("PK_Artist");
            modelBuilder.Entity<Release>()
                .ToTable("Release")
                .HasKey(x => x.ClusterId)
                .HasName("PK_Release");
            modelBuilder.Entity<Track>()
                .ToTable("Track")
                .HasKey(x => x.ClusterId)
                .HasName("PK_Track");

            modelBuilder.Entity<Track>().HasIndex(e => e.Id);
            modelBuilder.Entity<Artist>().HasIndex(e => e.Id);
            modelBuilder.Entity<Release>().HasIndex(e => e.Id);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Releases)
                .WithOne(r => r.Artist)
                .HasForeignKey(r => r.ArtistId);

            modelBuilder.Entity<Release>()
                .HasOne(r => r.Artist)
                .WithMany(a => a.Releases)
                .HasForeignKey(r => r.ArtistId);

            modelBuilder.Entity<Track>()
                .HasOne(t => t.Release)
                .WithMany(r => r.Tracks)
                .HasForeignKey(t => t.ReleaseId);

            modelBuilder.Entity<Track>()
                .HasOne(t => t.Artist)
                .WithMany(a => a.Tracks)
                .HasForeignKey(t => t.ArtistId);

            modelBuilder.Entity<Artist>()
                .Property(x => x.Name)
                .HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Release>()
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();
            modelBuilder.Entity<Track>()
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
