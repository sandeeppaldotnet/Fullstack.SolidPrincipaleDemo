using SolidPrincipaleDemo.Models;

namespace SolidPrincipaleDemo.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();

        Order? GetById(int id);

        Order Add(Order order);
    }
}
