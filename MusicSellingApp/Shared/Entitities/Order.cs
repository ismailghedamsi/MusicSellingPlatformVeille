namespace MusicSellingApp.Shared.Entitities
{
    public class Order
    {
        public Album Album { get; set; }
        public int Quantity { get; set; }

        public Order(Album album, int quantity)
        {
            Album = album;
            Quantity = quantity;
        }
    }
}