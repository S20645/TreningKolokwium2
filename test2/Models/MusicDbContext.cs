using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace test2.Models
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<MusicLabel> musicLabels { get; set; }
        public DbSet<Track> tracks { get; set; }

        public MusicDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var musicians = new List<Musician>
            {
                new Musician
                {
                    IdMusician = 1,
                    FirstName = "Jaj",
                    LastName = "jaj",
                    Nickname = "JJ"
                },
                new Musician
                {
                    IdMusician = 2,
                    FirstName = "KSD",
                    LastName = "DKS",
                    Nickname = null
                }
            };

            var tracks = new List<Track>
            {
                new Track
                {
                    IdTrack = 1,
                    TrackName = "Jj",
                    Duration = 2,
                    IdMusicAlbum = 1
                },
                new Track
                {
                    IdTrack = 2,
                    TrackName = "ss",
                    Duration = 3,
                    IdMusicAlbum = 1
                }
            };

            var musictracks = new List<Musician_Track>
            {
                new Musician_Track
                {
                    IdMusician = 1,
                    IdTrack = 1,
                }
            };

            var albums = new List<Album>
            {
                new Album
                {
                    IdAlbum = 1,
                    AlbumName = "KK",
                    PublishDate = System.DateTime.Today,
                    IdMusicLabel = 1,
                }
            };
            var musiclabels = new List<MusicLabel>
            {
                new MusicLabel
                {
                    IdMusicLabel = 1,
                    Name = "HAH"
                }
            };

            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.Nickname).HasMaxLength(20);

                e.HasData(musicians);

                e.ToTable("Musician");
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();
                e.Property(e => e.IdMusicAlbum);

                e.HasData(tracks);

                e.HasOne(e => e.Album)
                .WithMany(e => e.Tracks)
                .HasForeignKey(e => e.IdMusicAlbum)
                .OnDelete(DeleteBehavior.Restrict);

                e.ToTable("Track");
            });

            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.HasKey(e => e.IdMusician);

                e.HasData(musictracks);

                e.HasOne(e => e.Track)
                .WithMany(e => e.Musician_Tracks)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.Musician)
                .WithMany(e => e.Musician_Tracks)
                .HasForeignKey(e => e.IdMusician)
                .OnDelete(DeleteBehavior.Restrict);

                e.ToTable("Musician_Track");
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();
                e.Property(e => e.IdMusicLabel).IsRequired();

                e.HasData(albums);

                e.HasOne(e => e.MusicLabel)
                .WithMany(e => e.Albums)
                .HasForeignKey(e => e.IdMusicLabel)
                .OnDelete(DeleteBehavior.Restrict);

                e.ToTable("Album");
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();

                e.HasData(musiclabels);

                e.ToTable("MusicLabel");
            });
        }
    }
}
