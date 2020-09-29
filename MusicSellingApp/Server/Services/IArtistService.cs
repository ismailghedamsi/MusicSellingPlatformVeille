using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSellingApp.Server.Services
{
    public interface IArtistService
    {
        Task<Artist> GetArtistById(long id);
        Task<IEnumerable<Artist>> GetArtists();
        Task<Artist> DeleteArtist(Artist artist);
        public Task<Artist> PutArtist(long id, Album album);
        public Task<Artist> PostArtist(Artist album);
        public bool ArtistExists(long id);
    }
}
