﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Cart
    {
        public long Id { get; set; }
        public Fan fan { get; set; }
        public List<Order> orders;
    }
}
