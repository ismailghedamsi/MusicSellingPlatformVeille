using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSellingApp.Server;
using MusicSellingApp.Server.Services;
using MusicSellingApp.Shared.Entitities;

namespace MusicSellingApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAlbumService _albumRepository;

        public AlbumsController(ApplicationDbContext context, IAlbumService albumRepository)
        {
            _context = context;
            _albumRepository = albumRepository;
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            IEnumerable<Album> albums = await _albumRepository.GetAlbums();
            if (albums == null)
            {
                NotFound(albums);
            }
            return Ok(albums.ToList());
        }

        [HttpGet("{artistId}")]
        public async Task<ActionResult<List<Album>>> GetAlbumsOfArtist(long artistId)
        {
            var albums = await _albumRepository.GetAlbumsOfArtist(artistId);
            if (albums == null)
            {
                NotFound(albums);
            }
            return Ok(albums);
        }

        [HttpGet("{artistId}/{albumId}")]
        public async Task<ActionResult<Album>> GetAlbumsOfArtist(long artistId,long albumId)
        {
            var album = await _albumRepository.GetAlbumById(albumId);
            if (album == null)
            {
                NotFound(album);
            }
            return Ok(album);
        }



        // PUT: api/Albums/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(long id, Album album)
        {
            if (id != album.Id)
            {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Albums
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            //await _albumRepository.PostAlbum(album);
            if(album == null)
            {
                NotFound(album);
            }
            return CreatedAtAction("GetAlbum", new { id = album.Id }, album);
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> DeleteAlbum(long id)
        {
            var album = await _albumRepository.GetAlbumById(id);
            if (album == null)
            {
                return NotFound(album);
            }

            await _albumRepository.DeleteAlbum(album);

            return Ok(album);
        }

        private bool AlbumExists(long id)
        {
            return _albumRepository.AlbumExists(id);
        }
    }
}
