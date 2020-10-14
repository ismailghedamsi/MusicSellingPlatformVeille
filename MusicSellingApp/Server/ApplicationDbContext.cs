using Microsoft.EntityFrameworkCore;
using MusicSellingApp.Shared.Entitities;
using System;
using System.Linq;

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

        public DbSet<TodoItem> Todos { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Fan> Fans { get; set; }

        public DbSet<Album> Albums { get; set; }
  
        public DbSet<Cart> Carts { get; set; }
  
        public DbSet<Order> Orders { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<TrackList> TrackLists { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<FanAlbums> FanAlbums { get; set; }

        public DbSet<UploadedFile> UploadedFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<FanAlbums>()
           .HasKey(bc => new { bc.FanId, bc.AlbumId,bc.Id });
            modelBuilder.Entity<FanAlbums>()
                .HasOne(bc => bc.Album)
                .WithMany(b => b.FanAlbums)
                .HasForeignKey(bc => bc.AlbumId);
            modelBuilder.Entity<FanAlbums>()
                .HasOne(bc => bc.Fan)
                .WithMany(c => c.FanAlbums)
                .HasForeignKey(bc => bc.FanId);

            modelBuilder.Entity<Fan>()
            .HasOne(c => c.Cart)
            .WithOne(f => f.Fan)
            .HasForeignKey<Cart>(c => c.CartOwnerId);

            modelBuilder.Entity<Cart>()
            .HasMany(c => c.Orders)
            .WithOne(e => e.Cart);

            modelBuilder.Entity<Artist>()
            .HasIndex(u => u.Username)
            .IsUnique();

            modelBuilder.Entity<Artist>()
    .       HasIndex(u => u.Email)
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
