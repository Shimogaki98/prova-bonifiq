namespace ProvaPub.Strategy.PaymentStrategy
{
    public interface IPaymentStrategy
    {
        void Pay(decimal paymentValue, int customerId);
        IPaymentStrategy CreatePayment(string paymentMethod);
        IPaymentStrategy NextPaymentMethod { get; set; }
    }
}
