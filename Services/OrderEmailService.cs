using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Services
{
    public class OrderEmailService
    {
        private readonly IEmailSender _emailSender;

        public OrderEmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendOrderConfirmation(
            string customerEmail,
            string customerName)
        {
            var message =
                $"Hello {customerName}, your order has been confirmed.";

            _emailSender.SendEmail(customerEmail, message);
        }
    }

}
