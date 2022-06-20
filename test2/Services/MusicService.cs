using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using test2.Models;
using test2.Models.DTOs;

namespace test2.Services
{
    public class MusicService : IMusicService
    {
        private readonly MusicDbContext _context;

        public MusicService(MusicDbContext context)
        {
            _context = context;
        }

        public IQueryable<Album> GetAlbumsByID(int id)         // GR. A ZAD 1 
        {
            return _context.Albums
                .Include(e => e.Tracks)
                .Include(e => e.MusicLabel)
                .Where(e => e.IdAlbum == id);
        }

        public IQueryable<Track> GetTracksByID(int id)
        {
            return _context.tracks.Where(e => e.IdTrack == id);
        }

        public async Task<string> DeleteMusician(int id)
        {
            var wantedMusician = await _context.Musicians.FindAsync(id);

            if (wantedMusician == null)
                return "Can not find the musician!";

            var isHavingTracks = await _context.Musician_Tracks.AnyAsync(e => e.IdMusician == id);

            if (isHavingTracks)
                return "Cannot delete musician, because he has tracks!";

            _context.Remove(wantedMusician);
            await _context.SaveChangesAsync();

            return "Success!";
        }

        public async Task<string> AddTrack(TrackPost body)
        {
            try
            {
                await _context.AddAsync(new Track
                {
                    IdMusicAlbum = body.IdMusicAlbum,
                    IdTrack = body.IdTrack,
                    TrackName = body.TrackName,
                    Duration = body.Duration,
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return "blad";
            }

            return "Success!";
        }
    }
}
