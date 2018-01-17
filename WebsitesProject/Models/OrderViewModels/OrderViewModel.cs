namespace WebsitesProject.Models.OrderViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public int WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
