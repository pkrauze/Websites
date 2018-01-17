using System;
using System.ComponentModel.DataAnnotations;

namespace WebsitesProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Range(0, 9999.99)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Status { get; set; } 

        public virtual Website Website { get; set; }
    }
}
