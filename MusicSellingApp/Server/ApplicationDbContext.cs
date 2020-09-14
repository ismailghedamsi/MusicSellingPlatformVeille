using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSellingApp.Server
{
    public class ApplicationDbContext : DbContext
    {

     
        DbSet<Account> Accounts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Admin> Admins { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<Fan> Fans { get; set; }
        DbSet<Album> Albums { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Song> Songs { get; set; }
        DbSet<TrackList> TrackLists { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<MoviesActors>().HasKey(x => new { x.MovieId, x.PersonId });
            //modelBuilder.Entity<MoviesGenres>().HasKey(x => new { x.MovieId, x.GenreId });

            modelBuilder
       .Entity<Album>()
       .Property(e => e.Genre)
       .HasConversion(
           v => v.ToString(),
           v => (Genre)Enum.Parse(typeof(Genre), v));
            base.OnModelCreating(modelBuilder);
        }
    }
}
