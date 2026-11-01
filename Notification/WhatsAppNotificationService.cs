using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Notification
{
    public class WhatsAppNotificationService : IWhatsAppSender
    {
        public void SendWhatsApp(string phoneNumber, string message)
        {
            Console.WriteLine("Sending WhatsApp notification...");

            Console.WriteLine($"Phone: {phoneNumber}");

            Console.WriteLine($"Message: {message}");
        }
    }
}
