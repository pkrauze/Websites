using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebsitesProject.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Website> Websites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual IdentityRole Role { get; set; }
    }
}
