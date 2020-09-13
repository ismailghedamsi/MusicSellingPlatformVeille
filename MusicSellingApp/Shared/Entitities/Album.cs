using System;
using System.Collections.Generic;

namespace MusicSellingApp.Shared.Entitities
{
    public class Album
    {
        private string AlbumName { get; set; }
        private DateTime ReleaseDate { get; set; }

        private Genre Genre { get; set; }

        private string Cover { get; set; }

        private double Price { get; set; }

        private string Description { get; set; }

        private List<string> TrackList { get; set; }
    }
}