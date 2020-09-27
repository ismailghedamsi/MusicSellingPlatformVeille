using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSellingApp.Server.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDbContext _context;
        public AlbumService()
        {

        }

        public AlbumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AlbumExists(long id)
        {
            return _context.Albums.Any(e => e.Id == id);
        }

        public async Task<Album> DeleteAlbum(Album album)
        {
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task<Album> GetAlbumById(long id)
        {
            Album album = await _context.Albums.FindAsync(id);
            return album;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task<List<Album>> GetAlbumsOfArtist(long artistId)
        {
            List<Album> albums = await _context.Albums.Where(album => album.ArtistId == artistId).ToListAsync();
            return albums;
        }

        public async Task<Album> PostAlbum(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task<Album> PutAlbum(long id, Album album)
        {
            return await  _context.Albums.FirstAsync();
        }

 
    }
}
