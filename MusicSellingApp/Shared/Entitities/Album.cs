using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicSellingApp.Shared.Entitities
{
    public class Album
    {


        public long ArtistId { get; set; }
        public Artist Artist { get; set; }
        public long Id { get; set; }
        public string AlbumName { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        public string Cover { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public Album()
        {

        }


        public Album(string albumName, DateTime releaseDate, Genre genre, string cover, double price, string description)
        {
            AlbumName = albumName;
            ReleaseDate = releaseDate;
            Genre = genre;
            Cover = cover;
            Price = price;
            Description = description;
        }

        public override bool Equals(object obj)
        {
            return obj is Album album &&
                   ArtistId == album.ArtistId &&
                   EqualityComparer<Artist>.Default.Equals(Artist, album.Artist) &&
                   Id == album.Id &&
                   AlbumName == album.AlbumName &&
                   ReleaseDate == album.ReleaseDate &&
                   Genre == album.Genre &&
                   Cover == album.Cover &&
                   Price == album.Price &&
                   Description == album.Description;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(ArtistId);
            hash.Add(Artist);
            hash.Add(Id);
            hash.Add(AlbumName);
            hash.Add(ReleaseDate);
            hash.Add(Genre);
            hash.Add(Cover);
            hash.Add(Price);
            hash.Add(Description);
            return hash.ToHashCode();
        }
    }
}