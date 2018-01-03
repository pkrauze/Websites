using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebsitesProject.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Range(0, 9999.99)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Website> Websites { get; set; }

        public virtual User User { get; set; }
    }
}
