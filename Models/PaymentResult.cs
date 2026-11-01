namespace SolidPrincipaleDemo.Models
{
    public class PaymentResult
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; } = string.Empty;

        public string TransactionId { get; set; } = string.Empty;
    }

}
