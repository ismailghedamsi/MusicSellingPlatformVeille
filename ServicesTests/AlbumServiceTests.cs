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
    public class AlbumServiceTests
    {
        protected ApplicationDbContext MockContext;
        protected  AlbumService AlbumService;
        protected List<Album> MockData;
        protected DbSet<Album> MockSet;

        public AlbumServiceTests()
        {
        }

        [Fact]
        public async Task DeleteAlbum()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;
            Album album = null;
            var testingId = 457;

            using (var context = new ApplicationDbContext(options))
            {
                album = new Album { Id = testingId, AlbumName = "Album 1" };
                await context.Albums.AddAsync(album);
                context.SaveChanges();
            }


            using (var context = new ApplicationDbContext(options))
            {
                AlbumService albumService = new AlbumService(context);
                Album actual = await albumService.DeleteAlbum(album);
                Assert.Equal(album, actual);
            }
        }

        [Fact]
        public async Task SaveAlbumTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;
            var testingId = 457;
            Album album = new Album { Id = testingId, AlbumName = "Album 1" };


            using var context = new ApplicationDbContext(options);
            AlbumService albumService = new AlbumService(context);
            Album actual = await albumService.PostAlbum(album);
            Assert.Equal(album, actual);
        }


        [Fact]
        public async Task GetAlbumByIdTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
             .Options;
            Album album = null;
            var testingId = 5;
            // Insert seed data into the database using one instance of the context
            using (var context = new ApplicationDbContext(options))
            {
                 album = new Album { Id = testingId, AlbumName = "Album 1" };
                await context.Albums.AddAsync(album);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                AlbumService albumService = new AlbumService(context);
                Album actual = await albumService.GetAlbumById(testingId);
                Assert.Equal(album,actual);
            }

        }

        [Fact]
        public async Task GetAllAlbumTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ApplicationDbContext(options))
            {
                context.Albums.Add(new Album { Id = 100, AlbumName = "Album 1" });
                context.Albums.Add(new Album { Id = 101, AlbumName = "Album 2" });
                context.Albums.Add(new Album { Id = 102, AlbumName = "Album 3"});
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ApplicationDbContext(options))
            {
                AlbumService albumService = new AlbumService(context);
                IEnumerable<Album> albums = await albumService.GetAlbums();
    
            Assert.Equal(3, albums.ToList().Count);
            }
        }
    }

}

