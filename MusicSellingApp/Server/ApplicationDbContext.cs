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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
         {

         }

        public ApplicationDbContext()
        {

        }

        public virtual DbSet<TodoItem> Todos { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Fan> Fans { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<TrackList> TrackLists { get; set; }
        public virtual  DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<MoviesActors>().HasKey(x => new { x.MovieId, x.PersonId });
            //modelBuilder.Entity<MoviesGenres>().HasKey(x => new { x.MovieId, x.GenreId });


            modelBuilder.Entity<Album>()
            .HasOne(a => a.Artist)
            .WithMany(b => b.Discography);
            //.HasForeignKey(p => p.Id);



            modelBuilder.Entity<Artist>()
       .HasIndex(u => u.Username)
       .IsUnique();

            modelBuilder.Entity<Artist>()
    .HasIndex(u => u.Email)
    .IsUnique();


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
