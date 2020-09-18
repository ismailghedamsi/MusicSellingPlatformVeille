﻿using System;
using System.Collections.Generic;

namespace MusicSellingApp.Shared.Entitities
{
    public class Album
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public long Id { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }

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
    }
}