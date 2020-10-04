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
    public class FansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFanService _fanService;

        public FansController(ApplicationDbContext context, IFanService fanService)
        {
            _context = context;
            _fanService = fanService;
        }



        // GET: api/Fans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fan>>> GetFans()
        {
            IEnumerable<Fan> fans = await _fanService.GetFans();
            return Ok(fans);
        }

        // GET: api/Fans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fan>> GetFan(long id)
        {
            var fan = await _fanService.GetFanById(id);

            if (fan == null)
            {
                return NotFound();
            }

            return Ok(fan);
        }

        // PUT: api/Fans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFan(long id, Cart cart)
        {
            try
            {
                await _fanService.PutFan(id, cart);
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

            return Ok();
        }
        // POST: api/Fans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fan>> PostFan(Fan fan)
        {
            await _fanService.PostFan(fan);

            return StatusCode(201, fan);
        }

        // DELETE: api/Fans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fan>> DeleteFan(long id)
        {
            var fan = await _fanService.GetFanById(id);
            if (fan == null)
            {
                return NotFound();
            }

            await _fanService.DeleteFan(fan);

            return Ok(fan);
        }

        private bool FanExists(long id)
        {
            return _fanService.FanExists(id);
        }
    }
}
