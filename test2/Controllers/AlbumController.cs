using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using test2.Services;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMusicService _service;

        public AlbumController(IMusicService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)         // GR. A ZAD 1 
        {
            if(_service.GetAlbumsByID(id) == null)
                return NotFound();

            return Ok(
                await _service.GetAlbumsByID(id)
                .Select(e =>
                new Models.DTOs.Albums
                {
                    IdAlbum = e.IdAlbum,
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    MusicLabelName = e.MusicLabel.Name,
                    Tracks = e.Tracks.Select(t => new Models.DTOs.Tracks
                    {
                        TrackName = t.TrackName,
                        Duration = t.Duration,
                    }).ToList()
                }).ToListAsync()
            );
        }

    }
}
