using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Notification
{
    public class SmsNotificationService : ISmsSender
    {
        public void SendSms(string phoneNumber, string message)
        {
            Console.WriteLine("Sending SMS...");

            Console.WriteLine($"Phone: {phoneNumber}");

            Console.WriteLine($"Message: {message}");
        }
    }

}
