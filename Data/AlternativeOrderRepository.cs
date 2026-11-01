using SolidPrincipaleDemo.Interfaces;
using SolidPrincipaleDemo.Models;

namespace SolidPrincipaleDemo.Data
{
    public class AlternativeOrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = [];

        private int _nextId = 1;

        public List<Order> GetAll()
        {
            return _orders.ToList();
        }

        public Order? GetById(int id)
        {
            return _orders.FirstOrDefault(x => x.Id == id);
        }

        public Order Add(Order order)
        {
            order.Id = _nextId++;

            _orders.Add(order);

            return order;
        }
    }

}
