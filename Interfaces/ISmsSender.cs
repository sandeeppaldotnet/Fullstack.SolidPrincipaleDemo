namespace SolidPrincipaleDemo.Interfaces
{
    public interface ISmsSender
    {
        void SendSms(string phoneNumber, string message);
    }

}
