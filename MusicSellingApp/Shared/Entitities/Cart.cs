using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Cart
    {
        public long Id { get; set; }

        public long CartOwnerId { get; set; }
        public Fan Fan { get; set; }

        public List<Order> Orders { get; set; }

        public Cart()
        {

        }

        public Cart(Fan fan, List<Order> orders)
        {
            Fan = fan;
            Orders = orders;
        }
    }
}
