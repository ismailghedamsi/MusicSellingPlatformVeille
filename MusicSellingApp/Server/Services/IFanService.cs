using Microsoft.AspNetCore.Mvc;
using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSellingApp.Server.Services
{
    public interface IFanService
    {
        Task<Fan> GetFanById(long id);
        Task<IEnumerable<Fan>> GetFans();
        Task<Fan> DeleteFan(Fan fan);
        Task<Fan> PutFan(long id, Cart cart);
        Task<Fan> PostFan(Fan fan);
        bool FanExists(long id);
        Task<Fan> PutFanWithCart(Fan fan, Cart cart);
    }
}
