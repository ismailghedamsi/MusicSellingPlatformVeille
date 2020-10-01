using Microsoft.EntityFrameworkCore;
using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSellingApp.Server.Services
{
    public class FanService : IFanService
    {
        private readonly ApplicationDbContext _context;

        public FanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Fan> DeleteFan(Fan fan)
        {
            _context.Fans.Remove(fan);
            await _context.SaveChangesAsync();
            return fan;
        }

        public bool FanExists(long id)
        {
            return _context.Fans.Any(e => e.Id == id);
        }

        public async Task<Fan> GetFanById(long id)
        {
            return await _context.Fans.FindAsync(id);
        }

        public async Task<IEnumerable<Fan>> GetFans()
        {
            return await _context.Fans.ToListAsync();
        }

        public async Task<Fan> PostFan(Fan fan)
        {
            _context.Fans.Add(fan);
            await _context.SaveChangesAsync();
            return fan;
        }

        public async Task<Fan> PutFan(long id, Album album)
        {
            var fan = new Fan { Id = id };
            _context.Attach(fan);
            fan.Library.Add(album);
            await _context.SaveChangesAsync();
            return fan;
        }
    }
}
