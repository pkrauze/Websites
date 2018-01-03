using System;
using System.ComponentModel.DataAnnotations;

namespace WebsitesProject.Models
{
    public class Website
    {
        public int ID { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        public int OrderID { get; set; }

        public virtual Order Order { get; set; }
    }
}
