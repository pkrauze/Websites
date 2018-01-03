using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Websites.Models
{
    [Table("WebsiteTB")]
    public class Website
    {
        [Key]  
        public int WebsiteID { get; set; }  
        [Required(ErrorMessage = "Enter Domain")]
        public string Domain { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter domain create date")]
        public DateTime CreatedAt { get; set; }
        public int PageRank { get; set; }
        [Required(ErrorMessage = "Enter Domain Authority")]
        public int DomainAuthority { get; set; }
    }
}
