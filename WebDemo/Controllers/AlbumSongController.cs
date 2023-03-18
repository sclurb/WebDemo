using Microsoft.AspNetCore.Mvc;
using WebDemo.Models;


namespace WebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumSongController : ControllerBase
    {
        // GET: api/<AlbumSongController>
        [HttpGet("getAlbum")]
        public Task<IActionResult> GetAlbum()
        {
            var album = new Album()
            {
                AlbumId = 1,
                Title = "Goober",
                ReleaseDate = "May 1999",
                RecordedAt = "Special Studios",
                Length = "3:47",
                Producer = "Ted Templeman",
                SucceededBy = "Goober II",
                RecordedDate = "June 1987"
            };
            return Task.FromResult<IActionResult>(Ok(album));
        }
    }
}
