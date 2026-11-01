using SolidPrincipaleDemo.Interfaces;
using SolidPrincipaleDemo.Models;

namespace SolidPrincipaleDemo.Strategies
{
    public class CashPayment : IPaymentMethod
    {
        public string Name => "Cash";

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

            Console.WriteLine("Processing cash payment...");

            return new PaymentResult
            {
                IsSuccessful = true,
                Message = "Cash payment recorded.",
                TransactionId = Guid.NewGuid().ToString()
            };
        }
    }

}
