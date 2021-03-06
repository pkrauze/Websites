﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebsitesProject.Helpers.Validators;

namespace WebsitesProject.Models
{
    public class Website
    {
        public int WebsiteId { get; set; }

        public string Domain { get; set; }

        public string Description { get; set; }

        [Remote(action: "VerifyDomain", controller: "Websites", AdditionalFields = nameof(Domain))]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual User User { get; set; }
    }
}
