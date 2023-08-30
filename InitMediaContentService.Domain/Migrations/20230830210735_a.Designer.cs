﻿// <auto-generated />
using InitMediaContentService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InitMediaContentService.Domain.Migrations
{
    [DbContext(typeof(MediaContext))]
    [Migration("20230830210735_a")]
    partial class a
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InitMediaContentService.Domain.Entities.Artist", b =>
                {
                    b.Property<long>("ClusterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ClusterId"));

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("ClusterId")
                        .HasName("PK_Artist");

                    b.HasIndex("Id");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("InitMediaContentService.Domain.Entities.Release", b =>
                {
                    b.Property<long>("ClusterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ClusterId"));

                    b.Property<long>("ArtistId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("ClusterId")
                        .HasName("PK_Release");

                    b.HasIndex("ArtistId");

                    b.HasIndex("Id");

                    b.ToTable("Release", (string)null);
                });

            modelBuilder.Entity("InitMediaContentService.Domain.Entities.Track", b =>
                {
                    b.Property<long>("ClusterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ClusterId"));

                    b.Property<long>("ArtistId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<long>("ReleaseId")
                        .HasColumnType("bigint");

                    b.HasKey("ClusterId")
                        .HasName("PK_Track");

                    b.HasIndex("ArtistId");

                    b.HasIndex("Id");

                    b.HasIndex("ReleaseId");

                    b.ToTable("Track", (string)null);
                });

            modelBuilder.Entity("InitMediaContentService.Domain.Entities.Release", b =>
                {
                    b.HasOne("InitMediaContentService.Domain.Entities.Artist", "Artist")
                        .WithMany("Releases")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("InitMediaContentService.Domain.Entities.Track", b =>
                {
                    b.HasOne("InitMediaContentService.Domain.Entities.Artist", "Artist")
                        .WithMany("Tracks")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InitMediaContentService.Domain.Entities.Release", "Release")
                        .WithMany("Tracks")
                        .HasForeignKey("ReleaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Release");
                });

            modelBuilder.Entity("InitMediaContentService.Domain.Entities.Artist", b =>
                {
                    b.Navigation("Releases");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("InitMediaContentService.Domain.Entities.Release", b =>
                {
                    b.Navigation("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}