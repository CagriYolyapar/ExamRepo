using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthenticationTekrar.Models.Entities
{
    public class Order:BaseEntity
    {
        public string ShipAddress { get; set; }

        public string InvoiceAddress { get; set; }

        //Relational Properties

        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}