using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Notification
{
    public class EmailNotificationService : IEmailSender
    {
        public void SendEmail(string recipient, string message)
        {
            Console.WriteLine("Sending email...");

            Console.WriteLine($"To: {recipient}");

            Console.WriteLine($"Message: {message}");
        }
    }


}
