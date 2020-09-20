
using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace MusicSellingApp.Server.Repositories
{

    public class UserRepository : IUserRepository
    {

        ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeleteArtist(int artistId)
        {
            context.Artists.Where(x => x.Id == artistId).Delete();
        }

        public Artist GetArtistByID(int artistId)
        {
            return context.Artists.Find(artistId);
        }

        public IList<Artist> GetArtists()
        {

            return context.Users.OfType<Artist>().ToList();
        }

        public void InsertArtist(Artist artist)
        {
            context.Artists.Add(artist);
            context.SaveChanges();
        }


        public void UpdateArtist(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}
