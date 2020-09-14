using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class TrackList
    {
        public int Id { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }

}
