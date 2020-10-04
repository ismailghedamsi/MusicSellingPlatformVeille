namespace MusicSellingApp.Shared.Entitities
{
    public class Order
    {
        public long Id { get; set; }
        public Album Album { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }

        public Order()
        {
        }

        public Order(Album album, int quantity)
        {
            Album = album;
            Quantity = quantity;
        }
    }
}