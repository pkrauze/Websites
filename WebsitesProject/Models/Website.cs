using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebsitesProject.Models
{
    public class Website
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9][a-zA-Z0-9-_]{0,61}[a-zA-Z0-9]{0,1}\\.([a-zA-Z]{1,6}|[a-zA-Z0-9-]{1,30}\\.[a-zA-Z]{2,3})$")]
        public string Domain { get; set; }

        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
