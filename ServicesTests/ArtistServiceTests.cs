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
    public class ArtistServiceTests
    {
        protected ApplicationDbContext MockContext;
        protected  AlbumService AlbumService;
        protected List<Album> MockData;
        protected DbSet<Album> MockSet;

        public ArtistServiceTests()
        {
        }

        [Fact]
        public async Task DeleteArtist()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;
            Artist artist = null;
            var testingId = 457;

            using (var context = new ApplicationDbContext(options))
            {
                artist = new Artist { Id = testingId, Name = "Artist 1" };
                await context.Artists.AddAsync(artist);
                context.SaveChanges();
            }


            using (var context = new ApplicationDbContext(options))
            {
                ArtistService artistService = new ArtistService(context);
                Artist actual = await artistService.DeleteArtist(artist);
                Assert.Equal(artist, actual);
            }
        }

        [Fact]
        public async Task SaveArtistTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;
            var testingId = 457;
            Artist artist = new Artist { Id = testingId, Name = "Artist 1" };


            using ApplicationDbContext context = new ApplicationDbContext(options);
            ArtistService artistService = new ArtistService(context);
            Artist actual = await artistService.PostArtist(artist);
            Assert.Equal(artist, actual);
        }


        [Fact]
        public async Task GetArtistByIdTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
             .Options;
            Artist artist = null;
            var testingId = 5;
            // Insert seed data into the database using one instance of the context
            using (var context = new ApplicationDbContext(options))
            {
                 artist = new Artist { Id = testingId, Name = "Artist 1" };
                await context.Artists.AddAsync(artist);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                ArtistService artistService = new ArtistService(context);
                Artist actual = await artistService.GetArtistById(testingId);
                Assert.Equal(artist,actual);
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
                context.Artists.Add(new Artist { Id = 1, Name = "Artist 1" });
                context.Artists.Add(new Artist { Id = 2, Name = "Artist 2" });
                context.Artists.Add(new Artist { Id = 3, Name = "Artist 3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ApplicationDbContext(options))
            {
                ArtistService artistService = new ArtistService(context);
                IEnumerable<Artist> artists = await artistService.GetArtists();
    
            Assert.Equal(3, artists.ToList().Count);
            }
        }


    }

}

