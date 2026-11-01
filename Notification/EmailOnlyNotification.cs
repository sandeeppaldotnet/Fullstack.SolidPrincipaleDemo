using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Notification
{
    public class EmailOnlyNotification : INotificationService
    {
        public void SendEmail(string message)
        {
            throw new NotImplementedException();
        }

        public void SendPushNotification(string message)
        {
            throw new NotImplementedException();
        }

        public void SendSms(string message)
        {
            throw new NotImplementedException();
        }

        public void SendWhatsApp(string message)
        {
            throw new NotImplementedException();
        }
    }
}
