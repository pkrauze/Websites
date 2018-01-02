using System;
using System.ComponentModel.DataAnnotations;

namespace WebsitesProject.Models
{
    public class Website
    {
        public int ID { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
    }
}
