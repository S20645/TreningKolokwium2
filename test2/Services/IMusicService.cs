using System.Linq;
using System.Threading.Tasks;
using test2.Models;
using test2.Models.DTOs;

namespace test2.Services
{
    public interface IMusicService
    {
        IQueryable<Album> GetAlbumsByID(int id);          // GR. A ZAD 1 

        Task<string> DeleteMusician(int id);

        IQueryable<Track> GetTracksByID(int id);

        Task<string> AddTrack(TrackPost track);
    }
}
