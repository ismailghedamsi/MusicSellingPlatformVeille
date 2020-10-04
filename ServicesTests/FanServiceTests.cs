using Microsoft.EntityFrameworkCore;
using MusicSellingApp.Server;
using MusicSellingApp.Server.Services;
using MusicSellingApp.Shared.Entitities;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServicesTests
{
    public class FanServiceTests
    {
        protected ApplicationDbContext MockContext;
        protected  AlbumService AlbumService;

        public FanServiceTests()
        {
        }

        [Fact]
        public async Task DeleteFanTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;
            Fan fan = null;
            var testingId = 457;

            using (var context = new ApplicationDbContext(options))
            {
                fan = new Fan { Id = testingId, FirstName = "Ismail" };
                await context.Fans.AddAsync(fan);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                FanService fanService = new FanService(context);
                Fan actual = await fanService.DeleteFan(fan);
                Assert.Equal(fan, actual);
            }
        }

        [Fact]
        public async Task SaveFanTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;
            var testingId = 457;
            Fan fan = new Fan { Id = testingId, FirstName = "Fan 1" };


            using (var context = new ApplicationDbContext(options))
            {
                FanService fanService = new FanService(context);
                Fan actual = await fanService.PostFan(fan);
                Assert.Equal(fan, actual);
            }
        }


        [Fact]
        public async Task GetFanByIdTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
             .Options;
            Fan fan = null;
            var testingId = 5;
            // Insert seed data into the database using one instance of the context
            using (var context = new ApplicationDbContext(options))
            {
                 fan = new Fan { Id = testingId, FirstName = "Fan 1" };
                await context.Fans.AddAsync(fan);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                FanService fanService = new FanService(context);
                Fan actual = await fanService.GetFanById(testingId);
                Assert.Equal(fan,actual);
            }

        }

        [Fact]
        public async Task GetAllTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ApplicationDbContext(options))
            {
                context.Fans.Add(new Fan { Id = 1, FirstName = "Fan 1" });
                context.Fans.Add(new Fan { Id = 2, FirstName = "Fan 2" });
                context.Fans.Add(new Fan { Id = 3, FirstName = "Fan 3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ApplicationDbContext(options))
            {
                FanService fanService = new FanService(context);
                IEnumerable<Fan> fans = await fanService.GetFans();
            Assert.Equal(3, fans.ToList().Count);
            }
        }


    }

}

