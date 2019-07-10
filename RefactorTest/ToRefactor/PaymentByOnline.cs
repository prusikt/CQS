using RefactorTest.Domain;

namespace RefactorTest.ToRefactor
{
    public class PaymentByOnline : PaymentType
    {
        public PaymentInfo Pay;
        public bool IsReverse { get; set; }
        public bool OriginalLeg;

        public PaymentByOnline(PaymentInfo pay, bool originalLeg, bool isReverse)
        {
            Pay = pay;
            OriginalLeg = originalLeg;
            IsReverse = isReverse;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitPaymentByOnline(this);
        }
    }
}