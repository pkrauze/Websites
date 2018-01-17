using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebsitesProject.Helpers.Validators;

namespace WebsitesProject.Models.WebsiteViewModels
{
    public class WebsiteViewModel
    {
        public int WebsiteId { get; set; }

        public string Domain { get; set; }

        public string Description { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
