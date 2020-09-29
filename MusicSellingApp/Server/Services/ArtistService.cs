using Microsoft.EntityFrameworkCore;
using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSellingApp.Server.Services
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _context;

        public ArtistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ArtistExists(long id)
        {
            return _context.Artists.Any(e => e.Id == id);
        }

        public async Task<Artist> DeleteArtist(Artist artist)
        {
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> GetArtistById(long id)
        {
            return await _context.Artists.FindAsync(id);
        }

        public async Task<IEnumerable<Artist>> GetArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist> PostArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> PutArtist(long id, Album album)
        {
            var artist = new Artist { Id = id };
            _context.Attach(artist);
            artist.Discography.Add(album);
            await _context.SaveChangesAsync();
            return artist;
        }
    }
}
