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
        public  ApplicationDbContext Context { get; set; }


        public AlbumService()
        {

        }

        public AlbumService(ApplicationDbContext context)
        {
            Context = context;
        }

        public bool AlbumExists(long id)
        {
            return Context.Albums.Any(e => e.Id == id);
        }

        public async Task<Album> DeleteAlbum(Album album)
        {
            Context.Albums.Remove(album);
            await Context.SaveChangesAsync();
            return album;
        }

        public async Task<Album> GetAlbumById(long id)
        {
            Album album = await Context.Albums.FindAsync(id);
            return album;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            return await Context.Albums.Include(a => a.Artist).ToListAsync();
        }

        public async Task<List<Album>> GetAlbumsOfArtist(long artistId)
        {
            List<Album> albums = await Context.Albums.Where(album => album.ArtistId == artistId).ToListAsync();
            return albums;
        }

        public async Task<Album> PostAlbum(Album album)
        {
            Context.Albums.Add(album);
            await Context.SaveChangesAsync();
            return album;
        }

        public async Task<Album> PutAlbum(long id, Album album)
        {
            return await  Context.Albums.FirstAsync();
        }

 
    }
}
