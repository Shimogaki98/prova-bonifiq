using ProvaPub.Models;
using ProvaPub.Services.Interfaces;
using ProvaPub.Strategy.PaymentStrategy;

namespace ProvaPub.Services
{
    public class OrderService : IOrderService
    {
        PaymentStrategy _paymentStrategy;
        public OrderService(PaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            _paymentStrategy.Pay(paymentValue, customerId, paymentMethod);

            return await Task.FromResult(new Order()
            {
                Id = customerId,
                Value = paymentValue,
            });
        }
    }
}

