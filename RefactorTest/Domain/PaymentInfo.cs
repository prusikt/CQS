namespace RefactorTest.Domain
{
    /// <summary>
    /// Stores key information about a payment
    /// </summary>
    public class PaymentInfo
    {
        public int ID { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentMethod? ReversePaymentMethod { get; set; }
    }
}