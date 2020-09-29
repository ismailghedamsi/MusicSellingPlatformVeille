using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class ArtistsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IArtistService _artistService;

        public ArtistsController(ApplicationDbContext context, IArtistService artistService)
        {
            _context = context;
            _artistService = artistService;
        }

        // GET: api/Artists
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            IEnumerable<Artist> artists = await _artistService.GetArtists();
            if (artists == null)
            {
                return NotFound(artists);
            }
            return Ok(artists.ToList());
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(long id)
        {
            var artist = await _artistService.GetArtistById(id);

            if (artist == null)
            {
                return NotFound(artist);
            }

            return Ok(artist);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
   
        public async Task<IActionResult> PutArtist(long id, Album album)
        {
           
            try
            {
               await _artistService.PutArtist(id, album);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Artists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            await _artistService.PostArtist(artist);
            return StatusCode(201, artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(long id)
        {
            var artist = await _artistService.GetArtistById(id);
            if (artist == null)
            {
                return NotFound();
            }

            await _artistService.DeleteArtist(artist);

            return Ok(artist);
        }

        private bool ArtistExists(long id)
        {
            return _context.Artists.Any(e => e.Id == id);
        }
    }
}
