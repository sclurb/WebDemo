using Microsoft.AspNetCore.Mvc;
using WebDemo.Interfaces;
using WebDemo.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace WebDemo.Repositories
{
    public class AlbumSongRepository : IAlbumSongRepository
    {
        private readonly IConfiguration _configuration;

        public AlbumSongRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Album> GetAlbumAsync()
        {
            var album = new Album();
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var sql = "select * from Album";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                using (var rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        album.AlbumId = Convert.ToInt32(rdr["AlbumId"]);
                        album.Title = Convert.ToString(rdr["Title"]);
                        album.ReleaseDate = Convert.ToString(rdr["ReleaseDate"]);
                        album.RecordedAt = Convert.ToString(rdr["RecordedAt"]);
                        album.Length = Convert.ToString(rdr["RecordedDate"]);
                        album.Producer = Convert.ToString(rdr["Length"]);
                        album.SucceededBy = Convert.ToString(rdr["Producer"]);
                        album.RecordedDate = Convert.ToString(rdr["SucceededBy"]);
                    }
                }
            }
            return album;
        }

        public async Task<List<Album>> GetAlbumsAsync()
        {
            ;
            var albums = new List<Album>();
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var sql = "select * from Album";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                using (var rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        var album = new Album();
                        album.AlbumId = Convert.ToInt32(rdr["AlbumId"]);
                        album.Title = Convert.ToString(rdr["Title"]);
                        album.ReleaseDate = Convert.ToString(rdr["ReleaseDate"]);
                        album.RecordedAt = Convert.ToString(rdr["RecordedAt"]);
                        album.Length = Convert.ToString(rdr["RecordedDate"]);
                        album.Producer = Convert.ToString(rdr["Length"]);
                        album.SucceededBy = Convert.ToString(rdr["Producer"]);
                        album.RecordedDate = Convert.ToString(rdr["SucceededBy"]);
                        albums.Add(album);
                    }
                }
                cmd.Connection.Close();
            }
            return albums;
        }

        public async Task<List<Song>> GetSongsAsync()
        {
            
            var songs = new List<Song>();
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var sql = "select * from Song";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                using (var rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        var song = new Song();
                        song.AlbumId = Convert.ToInt32(rdr["AlbumId"]);
                        song.Title = Convert.ToString(rdr["Title"]);
                        song.AlbumName = Convert.ToString(rdr["AlbumName"]);
                        song.Band = Convert.ToString(rdr["Band"]);
                        song.Length = Convert.ToString(rdr["Length"]);
                        song.SongWriters = Convert.ToString(rdr["SongWriters"]);
                        song.YouTubeUrl = Convert.ToString(rdr["YouTubeUrl"]);
                        songs.Add(song);
                    }
                    
                }
                cmd.Connection.Close();
            }
            return songs;
        }

        public async Task InsertAlbumsAsync(List<Album> albums)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var sql = @$"
                        Insert Into Album
                        (Albumid, Title, ReleaseDate, RecordedAt, RecordedDate, Length, Producer, SucceededBy)
                        Values
                        (@Albumid, @Title, @ReleaseDate, @RecordedAt, @RecordedDate, @Length, @Producer, @SucceededBy)
                        ";
            using (var connection = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.Add("@AlbumId", SqlDbType.Int);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.NVarChar);
                cmd.Parameters.Add("@RecordedAt", SqlDbType.NVarChar);
                cmd.Parameters.Add("@RecordedDate", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Length", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Producer", SqlDbType.NVarChar);
                cmd.Parameters.Add("@SucceededBy", SqlDbType.NVarChar);

                foreach (var album in albums)
                {
                    cmd.Parameters["@AlbumId"].Value = album.AlbumId;
                    cmd.Parameters["@Title"].Value = album.Title;
                    cmd.Parameters["@ReleaseDate"].Value = album.RecordedDate;
                    cmd.Parameters["@RecordedAt"].Value = album.RecordedAt;
                    cmd.Parameters["@RecordedDate"].Value = album.RecordedDate;
                    cmd.Parameters["@Length"].Value = album.Length;
                    cmd.Parameters["@Producer"].Value = album.Producer;
                    cmd.Parameters["@SucceededBy"].Value = album.SucceededBy;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }


            }
            foreach (var album in albums)
            {
                await Console.Out.WriteLineAsync($"Here is the Album {album.AlbumId} Tites: {album.Title}");
            }
        }

        public async Task InsertSongsAsync(List<Song> songs)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var sql = @$"
                        Insert Into Song
                        (Albumid, Title, AlbumName, Band, Length, SongWriters, YouTubeUrl)
                        Values
                        (@Albumid, @Title, @AlbumName, @Band, @Length, @SongWriters, @YouTubeUrl)
                        ";
            using (var connection = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.Add("@AlbumId", SqlDbType.Int);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar);
                cmd.Parameters.Add("@AlbumName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Band", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Length", SqlDbType.NVarChar);
                cmd.Parameters.Add("@SongWriters", SqlDbType.NVarChar);
                cmd.Parameters.Add("@YouTubeUrl", SqlDbType.NVarChar);

                foreach (var song in songs)
                {
                    cmd.Parameters["@AlbumId"].Value = song.AlbumId;
                    cmd.Parameters["@Title"].Value = song.Title;
                    cmd.Parameters["@AlbumName"].Value = song.AlbumName;
                    cmd.Parameters["@Band"].Value = song.Band;
                    cmd.Parameters["@Length"].Value = song.Length;
                    cmd.Parameters["@SongWriters"].Value = song.SongWriters;
                    cmd.Parameters["@YouTubeUrl"].Value = song.YouTubeUrl;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            foreach (var song in songs)
            {
                await Console.Out.WriteLineAsync($"Here is the Album {song.AlbumId} Tites: {song.Title}");
            }
        }
    }
}
