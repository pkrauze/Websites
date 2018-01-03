using System;
using System.Collections.Generic;

namespace WebsitesProject.Models
{
    public class Order
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Website> Websites { get; set; }
    }
}
