namespace SolidPrincipaleDemo.Interfaces
{
    public interface INotificationService
    {
        void SendEmail(string message);

        void SendSms(string message);

        void SendWhatsApp(string message);

        void SendPushNotification(string message);
    }

}
