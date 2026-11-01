using SolidPrincipaleDemo.Interfaces;
using SolidPrincipaleDemo.Models;

namespace SolidPrincipaleDemo.Strategies
{
    public class UpiPayment : IPaymentMethod
    {
        public string Name => "UPI";

        public PaymentResult Pay(decimal amount)
        {
            if (amount <= 0)
            {
                return new PaymentResult
                {
                    IsSuccessful = false,
                    Message = "Amount must be greater than zero."
                };
            }

            Console.WriteLine("Processing UPI payment...");

            return new PaymentResult
            {
                IsSuccessful = true,
                Message = "UPI payment successful.",
                TransactionId = Guid.NewGuid().ToString()
            };
        }
    }

}
