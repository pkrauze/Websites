namespace WebsitesProject.Models.OrderViewModels
{
    public class DeleteOrderViewModel
    {
        public int OrderId { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public Website Website { get; set; }
    }
}
