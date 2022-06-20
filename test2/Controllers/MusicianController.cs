using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using test2.Services;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicService _service;

        public MusicianController(IMusicService service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _service.DeleteMusician(id);

            if (result != "Success!")
                return BadRequest();

            return Ok(result);
        }
    }
}
