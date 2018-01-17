using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebsitesProject.Helpers.Validators;

namespace WebsitesProject.Models.WebsiteViewModels
{
    public class CreateWebsiteViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9][a-zA-Z0-9-_]{0,61}[a-zA-Z0-9]{0,1}\\.([a-zA-Z]{1,6}|[a-zA-Z0-9-]{1,30}\\.[a-zA-Z]{2,3})$")]
        public string Domain { get; set; }

        [Capitalized]
        public string Description { get; set; }

        [PastDate]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
