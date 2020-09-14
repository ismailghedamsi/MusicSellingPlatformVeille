using System;
using System.Collections.Generic;

namespace MusicSellingApp.Shared.Entitities
{
    public class Album
    {
        public long Id { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        public string Cover { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public TrackList TrackList { get; set; }
    }
}