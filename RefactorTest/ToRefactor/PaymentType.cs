namespace RefactorTest.ToRefactor
{
    public abstract class PaymentType
    {
        public abstract void Accept(IVisitor visitor);
    }
}