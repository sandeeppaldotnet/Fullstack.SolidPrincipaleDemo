namespace SolidPrincipaleDemo.Models
{
    public class Order
    {

        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Pending";
    }
}
