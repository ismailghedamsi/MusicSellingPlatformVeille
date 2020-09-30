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
    public class UnitTest1
    {
        protected ApplicationDbContext MockContext;
        protected  AlbumService AlbumService;
        protected List<Album> MockData;
        protected DbSet<Album> MockSet;
        Album album;
        public UnitTest1()
        {
          
        }


        [Fact]
        public async Task Test1()
        {
            MockContext = MockRepository.Mock<ApplicationDbContext>();
            MockSet = MockRepository.Mock<DbSet<Album>>();
            AlbumService.Context = MockContext;
            MockContext.Albums = MockSet;

            album = new Album
            {
                AlbumName = "Album1",
                Id = 1
            };

            MockData = new List<Album>() {
                new Album()

            };

            var expected = await AlbumService.PostAlbum(album);
            Assert.Equal(expected, album);

        }

    }

}

