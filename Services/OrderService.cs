using SolidPrincipaleDemo.Interfaces;
using SolidPrincipaleDemo.Models;

namespace SolidPrincipaleDemo.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;
        private readonly PricingService _pricingService;

        public OrderService(
            IOrderRepository repository,
            PricingService pricingService)
        {
            _repository = repository;
            _pricingService = pricingService;
        }

        public List<Order> GetAllOrders()
        {
            return _repository.GetAll();
        }

        public Order? GetOrderById(int id)
        {
            return _repository.GetById(id);
        }

        public Order CreateOrder(CreateOrderRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CustomerName))
            {
                throw new ArgumentException("Customer name is required.");
            }

            if (request.Amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }

            var discount = _pricingService.CalculateDiscount(
                request.CustomerType,
                request.Amount);

            var order = new Order
            {
                CustomerName = request.CustomerName,
                Amount = request.Amount,
                Discount = discount,
                TotalAmount = request.Amount - discount,
                Status = "Pending"
            };

            return _repository.Add(order);
        }
    }

}
