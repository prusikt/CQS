using RefactorTest.Domain;

namespace RefactorTest.ToRefactor
{
    public class PaymentByWebEntry : PaymentType
    {
        public PaymentInfo Pay;
        public bool IsReverse { get; set; }

        public PaymentByWebEntry(PaymentInfo pay, bool isReverse)
        {
            IsReverse = isReverse;
            Pay = pay;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitPaymentByWebEntry(this);
        }
    }
}