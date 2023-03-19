using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebDemo.Interfaces;
using WebDemo.Models;


namespace WebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumSongController : ControllerBase
    {
        private readonly IAlbumSongRepository _repo;
        public AlbumSongController(IAlbumSongRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("getAlbums")]
        public async Task<IActionResult> GetAlbums()
        {
            var result = await _repo.GetAlbumsAsync();
            return Ok(result);
        }

        [HttpGet("getSongs")]
        public async Task<IActionResult> GetSongs()
        {
            var result = await _repo.GetSongsAsync();
            return Ok(result);
        }

        [HttpPost("insertAlbums")]
        public async Task<IActionResult> PostAlbum([FromBody] List<Album> albums)
        {
            await _repo.InsertAlbumsAsync(albums);
            return Ok();
        }

        [HttpPost("insertSongs")]
        public async Task<IActionResult> PostSongs([FromBody] List<Song> songs)
        {
            await _repo.InsertSongsAsync(songs);
            return Ok();
        }
    }
}
