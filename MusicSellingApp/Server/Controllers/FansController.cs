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
    public class FansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Fans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fan>>> GetFans()
        {
            return await _context.Fans.ToListAsync();
        }

        // GET: api/Fans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fan>> GetFan(long id)
        {
            var fan = await _context.Fans.FindAsync(id);

            if (fan == null)
            {
                return NotFound();
            }

            return fan;
        }

        // PUT: api/Fans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFan(long id, Fan fan)
        {
            if (id != fan.Id)
            {
                return BadRequest();
            }

            _context.Entry(fan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FanExists(id))
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

        // POST: api/Fans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fan>> PostFan(Fan fan)
        {
            _context.Fans.Add(fan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFan", new { id = fan.Id }, fan);
        }

        // DELETE: api/Fans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fan>> DeleteFan(long id)
        {
            var fan = await _context.Fans.FindAsync(id);
            if (fan == null)
            {
                return NotFound();
            }

            _context.Fans.Remove(fan);
            await _context.SaveChangesAsync();

            return fan;
        }

        private bool FanExists(long id)
        {
            return _context.Fans.Any(e => e.Id == id);
        }
    }
}
