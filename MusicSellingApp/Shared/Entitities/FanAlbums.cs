namespace MusicSellingApp.Shared.Entitities
{
    public class FanAlbums
    {
        public long Id { get; set; }
        public long FanId { get; set; }
       
        public Fan Fan { get; set; }
        public long AlbumId { get; set; }
        public Album Album { get; set; }

        public FanAlbums()
        {
  
        }
    }
}
