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
        [Remote(action: "VerifyDomain", controller: "Websites", AdditionalFields = nameof(CreatedAt))]
        [RegularExpression("^[a-zA-Z0-9][a-zA-Z0-9-_]{0,61}[a-zA-Z0-9]{0,1}\\.([a-zA-Z]{1,6}|[a-zA-Z0-9-]{1,30}\\.[a-zA-Z]{2,3})$")]
        public string Domain { get; set; }

        [Capitalized]
        [Remote("Foo", "Websites", ErrorMessage = "Remote validation is working")]
        public string Description { get; set; }

        [PastDate]
        [DataType(DataType.Date)]
        [Remote(action: "VerifyDomain", controller: "Websites", AdditionalFields = nameof(Domain))]
        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
