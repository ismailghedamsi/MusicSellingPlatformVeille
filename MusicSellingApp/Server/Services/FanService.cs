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

        public async Task<Fan> PutFan(long id, Cart cart)
        {
            var fan = new Fan { Id = id };
            _context.Attach(fan);
            fan.Cart = cart;
            //fan.Library.Add(album);
            await _context.SaveChangesAsync();
            return fan;
        }

        public async Task<Fan> PutFanWithCart(Fan fan,Cart cart)
        {

            fan.Cart = cart;

            // Attach target with old customer
            _context.Fans.Attach(fan);
            // Attach second customer
            _context.Carts.Attach(cart);


            // Change target's state to Modified
            _context.Entry(fan).State = EntityState.Modified;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            return fan;
        }
    }
}
