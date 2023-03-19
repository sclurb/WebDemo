using WebDemo.Models;

namespace WebDemo.Interfaces
{
    public interface IAlbumSongRepository
    {
        Task<Album> GetAlbumAsync();
        Task<List<Album>> GetAlbumsAsync();
        Task<List<Song>> GetSongsAsync();
        Task InsertAlbumsAsync(List<Album> album);
        Task InsertSongsAsync(List<Song> songs);
    }
}