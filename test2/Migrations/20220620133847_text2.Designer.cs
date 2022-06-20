﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test2.Models;

namespace test2.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    [Migration("20220620133847_text2")]
    partial class text2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("test2.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "KK",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("test2.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabel");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "HAH"
                        });
                });

            modelBuilder.Entity("test2.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musician");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Jaj",
                            LastName = "jaj",
                            Nickname = "JJ"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "KSD",
                            LastName = "DKS"
                        });
                });

            modelBuilder.Entity("test2.Models.Musician_Track", b =>
                {
                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusician");

                    b.HasIndex("IdTrack");

                    b.ToTable("Musician_Track");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            IdTrack = 1
                        });
                });

            modelBuilder.Entity("test2.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Track");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 2f,
                            IdMusicAlbum = 1,
                            TrackName = "Jj"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 3f,
                            IdMusicAlbum = 1,
                            TrackName = "ss"
                        });
                });

            modelBuilder.Entity("test2.Models.Album", b =>
                {
                    b.HasOne("test2.Models.MusicLabel", "MusicLabel")
                        .WithMany("Albums")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("test2.Models.Musician_Track", b =>
                {
                    b.HasOne("test2.Models.Musician", "Musician")
                        .WithMany("Musician_Tracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("test2.Models.Track", "Track")
                        .WithMany("Musician_Tracks")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("test2.Models.Track", b =>
                {
                    b.HasOne("test2.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("test2.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("test2.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("test2.Models.Musician", b =>
                {
                    b.Navigation("Musician_Tracks");
                });

            modelBuilder.Entity("test2.Models.Track", b =>
                {
                    b.Navigation("Musician_Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}