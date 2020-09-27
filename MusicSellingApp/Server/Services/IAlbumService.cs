using Microsoft.AspNetCore.Mvc;
using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSellingApp.Server.Services
{
    public interface IAlbumService
    {
        Task<Album> GetAlbumById(long id);
        Task<IEnumerable<Album>> GetAlbums();
        Task<Album> DeleteAlbum(Album album);
        Task<List<Album>> GetAlbumsOfArtist(long artistId);
      // public Task<Artist> PutAlbum(long id, Album album);
        public Task<Album> PostAlbum(Album album);
        public bool AlbumExists(long id);
    }
}
