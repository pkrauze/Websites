using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebsitesProject.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Please compare your password")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Website> Websites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
