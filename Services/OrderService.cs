using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class OrderService
    {
        public async Task<Order> PayOrder(IPaymentMethod paymentMethod, decimal paymentValue, int customerId)
        {
            paymentMethod.Pay(paymentValue, customerId);

            return await Task.FromResult(new Order()
            {
                Id = customerId,
                Value = paymentValue,
            });
        }
    }

    // Abstração para possível extensão de metodos de pagamento, sem alterar o método "Original" respeitando o princípio Open-Closed 

    public interface IPaymentMethod
    {
        public void Pay(decimal paymentValue, int customerId);
    }

    public class Pix : IPaymentMethod
    {
        public void Pay(decimal paymentValue, int customerId)
        {
            // Pay with Pix
        }
    }
    public class CreditCard : IPaymentMethod
    {
        public void Pay(decimal paymentValue, int customerId)
        {
            // Pay with Credit Card
        }
    }

    public class Paypal : IPaymentMethod
    {
        public void Pay(decimal paymentValue, int customerId)
        {
            // Pay with Paypal
        }
    }


    // Service e factory para evitar IF nos Controllers e Services
    public interface IPaymentService
    {
        IPaymentMethod CreatePaymentClass(string payment);
    }

    public class PaymentService : IPaymentService
    {
        private readonly Dictionary<string, Func<IPaymentMethod>> _PaymentMethodFactories;

        public PaymentService()
        {
            _PaymentMethodFactories = new Dictionary<string, Func<IPaymentMethod>>
        {
            { "pix".ToLower(), () => new Pix() },
            { "creditcard".ToLower(), () => new CreditCard() },
            { "paypal".ToLower(), () => new Paypal() },
        };
        }

        public IPaymentMethod CreatePaymentClass(string payment)
        {
            if (_PaymentMethodFactories.TryGetValue(payment, out var factory))
            {
                return factory();
            }

            throw new ArgumentException("Invalid Payment Method");
        }
    }
}
