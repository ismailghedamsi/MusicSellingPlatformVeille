using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSellingApp.Server.Repositories
{
    public interface IUserRepository
    {

        IList<Artist> GetArtists();
        Artist GetArtistByID(int artistId);
        void InsertArtist(Artist artist);
        void DeleteArtist(int artistId);
        void UpdateArtist(Artist artist);
    }
}
