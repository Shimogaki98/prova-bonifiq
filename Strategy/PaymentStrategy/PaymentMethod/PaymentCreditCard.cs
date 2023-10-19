using ProvaPub.Services;

namespace ProvaPub.Strategy.PaymentStrategy.PaymentMethod
{
    public class PaymentCreditCard : IPaymentStrategy
    {

        public IPaymentStrategy NextPaymentMethod { get; set; }

        public IPaymentStrategy CreatePayment(string paymentMethod)
        {
            if (paymentMethod.ToLower() != "creditcard")
                return NextPaymentMethod.CreatePayment(paymentMethod);
            return this;
        }

        public void Pay(decimal paymentValue, int customerId)
        {
            // Pay with Credit Card
        }
    }
}
