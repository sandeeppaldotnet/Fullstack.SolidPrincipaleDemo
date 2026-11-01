using SolidPrincipaleDemo.Interfaces;
using SolidPrincipaleDemo.Models;

namespace SolidPrincipaleDemo.Strategies
{
    public class CardPayment : IPaymentMethod
    {
        public string Name => "Card";

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

            Console.WriteLine("Processing card payment...");

            return new PaymentResult
            {
                IsSuccessful = true,
                Message = "Card payment successful.",
                TransactionId = Guid.NewGuid().ToString()
            };
        }
    }

}
