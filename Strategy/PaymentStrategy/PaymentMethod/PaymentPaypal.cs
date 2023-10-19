namespace ProvaPub.Strategy.PaymentStrategy.PaymentMethod
{
    public class PaymentPaypal : IPaymentStrategy
    {
        public IPaymentStrategy NextPaymentMethod { get; set; }

        public IPaymentStrategy CreatePayment(string paymentMethod)
        {
            if (paymentMethod.ToLower() != "paypal")
                return NextPaymentMethod.CreatePayment(paymentMethod);
            return this;
        }

        public void Pay(decimal paymentValue, int customerId)
        {
            // Pay with Paypal
        }
    }
}
