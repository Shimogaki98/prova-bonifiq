namespace ProvaPub.Strategy.PaymentStrategy.PaymentMethod
{
    public class PaymentNotFound : IPaymentStrategy
    {
        public IPaymentStrategy NextPaymentMethod { get; set; }

        public IPaymentStrategy CreatePayment(string paymentMethod)
        {
            return this;
        }

        public void Pay(decimal paymentValue, int customerId)
        {
            // Payment method not found //
        }
    }
}
