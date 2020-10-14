using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSellingApp.Server;
using MusicSellingApp.Shared.Entitities;

namespace MusicSellingApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FanAlbumsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FanAlbumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FanAlbums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FanAlbums>>> GetFanAlbums()
        {
            return await _context.FanAlbums.Include(a => a.Fan).Include(a => a.Album ).ToListAsync();
        }

        // GET: api/FanAlbums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FanAlbums>> GetFanAlbums(long id)
        {
            var fanAlbums = await _context.FanAlbums.FindAsync(id);

            if (fanAlbums == null)
            {
                return NotFound();
            }

            return fanAlbums;
        }

        [HttpGet("Fan/{id}")]
        public async Task<ActionResult<List<FanAlbums>>> GetAlbumsByFanId(long fanId)
        {
            var fanAlbums = await _context.FanAlbums.Where(fa => fa.FanId == fanId).ToListAsync();
            if (fanAlbums == null)
            {
                return NotFound();
            }

            return fanAlbums;
        }



        // PUT: api/FanAlbums/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFanAlbums(long id, FanAlbums fanAlbums)
        {
            if (id != fanAlbums.FanId)
            {
                return BadRequest();
            }

            _context.Entry(fanAlbums).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FanAlbumsExists(id))
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

        // POST: api/FanAlbums
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FanAlbums>> PostFanAlbums(FanAlbums fanAlbums)
        {
            _context.FanAlbums.Add(fanAlbums);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FanAlbumsExists(fanAlbums.FanId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFanAlbums", new { id = fanAlbums.FanId }, fanAlbums);
        }

        // DELETE: api/FanAlbums/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FanAlbums>> DeleteFanAlbums(long id)
        {
            var fanAlbums = await _context.FanAlbums.FindAsync(id);
            if (fanAlbums == null)
            {
                return NotFound();
            }

            _context.FanAlbums.Remove(fanAlbums);
            await _context.SaveChangesAsync();

            return fanAlbums;
        }

        private bool FanAlbumsExists(long id)
        {
            return _context.FanAlbums.Any(e => e.FanId == id);
        }
    }
}
