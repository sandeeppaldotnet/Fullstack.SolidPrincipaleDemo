using SolidPrincipaleDemo.Interfaces;
using SolidPrincipaleDemo.Models;

namespace SolidPrincipaleDemo.Services
{
    public class PaymentService
    {
        private readonly IEnumerable<IPaymentMethod> _paymentMethods;

        public PaymentService(
            IEnumerable<IPaymentMethod> paymentMethods)
        {
            _paymentMethods = paymentMethods;
        }

        public PaymentResult ProcessPayment(
            string paymentMethod,
            decimal amount)
        {
            var selectedMethod = _paymentMethods.FirstOrDefault(
                x => x.Name.Equals(
                    paymentMethod,
                    StringComparison.OrdinalIgnoreCase));

            if (selectedMethod is null)
            {
                return new PaymentResult
                {
                    IsSuccessful = false,
                    Message = "Payment method not supported."
                };
            }

            return selectedMethod.Pay(amount);
        }
    }

}
