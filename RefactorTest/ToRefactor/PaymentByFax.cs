using RefactorTest.Domain;

namespace RefactorTest.ToRefactor
{
    public class PaymentByFax : PaymentType
    {
        public PaymentInfo PaymentInfo;
        public PaymentByFax(PaymentInfo  paymentInfo,bool isReverse)
        {
            PaymentInfo = paymentInfo;
            IsReverse = isReverse;
        }

        public bool IsReverse { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitPaymentByFax(this);
        }
    }
}