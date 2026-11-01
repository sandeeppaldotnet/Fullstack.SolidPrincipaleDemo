namespace SolidPrincipaleDemo.Models
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;
    }

}
