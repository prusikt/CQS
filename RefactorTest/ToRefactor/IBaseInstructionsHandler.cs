using RefactorTest.Domain;

namespace RefactorTest.ToRefactor
{
    public abstract class IBaseInstructionsHandler
    {
        public abstract void ProcessInstruction(PaymentInfo pay);
        public abstract void ProcessInstruction(PaymentInfo pay, bool originalLeg);
    }
}