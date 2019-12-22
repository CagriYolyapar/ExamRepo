﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthenticationTekrar.Models.Entities
{
    public class CartItem
    {
        public int ID { get; set; }
        public short Amount { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get { return Price * Amount; } }
        public CartItem()
        {
            Amount++;
        }
    }
}