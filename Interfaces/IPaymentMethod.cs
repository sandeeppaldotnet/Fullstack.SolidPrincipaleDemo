using SolidPrincipaleDemo.Models;

namespace SolidPrincipaleDemo.Interfaces
{
    public interface IPaymentMethod
    {
        string Name { get; }

        PaymentResult Pay(decimal amount);
    }

}
