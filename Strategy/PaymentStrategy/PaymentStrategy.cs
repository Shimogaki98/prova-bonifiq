
using ProvaPub.Strategy.PaymentStrategy.PaymentMethod;

namespace ProvaPub.Strategy.PaymentStrategy
{
    public class PaymentStrategy
    {
        public void Pay(decimal paymentValue, int customerId, string paymentMethod)
        {
            var pix = new PaymentPix();
            var paypal = new PaymentPaypal();
            var creditCard = new PaymentCreditCard();
            var notFound = new PaymentNotFound();

            pix.NextPaymentMethod = paypal;
            paypal.NextPaymentMethod = creditCard;
            creditCard.NextPaymentMethod = notFound;

            var pay = pix.CreatePayment(paymentMethod);
            pay.Pay(paymentValue, customerId);
        }
    }
}
