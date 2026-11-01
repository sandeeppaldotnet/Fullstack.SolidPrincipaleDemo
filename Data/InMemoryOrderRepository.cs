using SolidPrincipaleDemo.Interfaces;
using SolidPrincipaleDemo.Models;

namespace SolidPrincipaleDemo.Data
{
    public class InMemoryOrderRepository : IOrderRepository
    {

        private static readonly List<Order> _orders =
   [
       new Order
        {
            Id = 1,
            CustomerName = "Rahul",
            Amount = 2000,
            Discount = 200,
            TotalAmount = 1800,
            Status = "Completed"
        },
        new Order
        {
            Id = 2,
            CustomerName = "Priya",
            Amount = 1500,
            Discount = 100,
            TotalAmount = 1400,
            Status = "Pending"
        }
   ];

        private static int _nextId = 3;
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
