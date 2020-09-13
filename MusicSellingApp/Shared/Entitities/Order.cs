namespace MusicSellingApp.Shared.Entitities
{
    public class Order
    {
        public Album Album { get; set; }
        public int quantity;

        public Order(Album album, int quantity)
        {
            Album = album;
            this.quantity = quantity;
        }
    }
}