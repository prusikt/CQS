namespace RefactorTest.ToRefactor
{
    public interface IVisitor
    {
        void VisitPaymentByFax(PaymentByFax paymentByFax);
        void VisitPaymentByOnline(PaymentByOnline paymentByOnline);
        void VisitPaymentByWebEntry(PaymentByWebEntry paymentByWebEntry);
    }
}