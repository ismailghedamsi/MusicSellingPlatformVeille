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


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //    .AddJsonFile("appsettings.json")
        //    .Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //    optionsBuilder.EnableSensitiveDataLogging();
        //    base.OnConfiguring(optionsBuilder);
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }

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
