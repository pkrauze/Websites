using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebsitesProject.Helpers.Validators;

namespace WebsitesProject.Models.OrderViewModels
{
    public class EditOrderViewModel
    {
        public int OrderId { get; set; }

        [Range(0, 9999.99)]
        public decimal Price { get; set; }

        [Capitalized]
        public string Description { get; set; }

        public string Status { get; set; }

        [Required]
        [Display(Name = "Website")]
        public int WebsiteId { get; set; }

        public IEnumerable<Website> Websites { get; set; }
    }
}
