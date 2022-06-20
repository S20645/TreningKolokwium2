using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
using test2.Models;
using test2.Models.DTOs;
using test2.Services;
using System.Collections.Generic;
using System;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly IMusicService _service;

        public TrackController(IMusicService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrackPost body)
        {
            if(!ModelState.IsValid)
                return BadRequest("Zle cialo");
            if (await _service.GetTracksByID(body.IdTrack).FirstOrDefaultAsync() != null)
                return BadRequest("Istnieje juz track o podanym ID");
            if (await _service.GetAlbumsByID(body.IdMusicAlbum).FirstOrDefaultAsync() is null)
                return BadRequest("Nie istnieje album o podanym ID");

            var result = await _service.AddTrack(body);

            if(result != "Success!")
                return BadRequest(result);

            return Ok(result);
        }
    }
}
