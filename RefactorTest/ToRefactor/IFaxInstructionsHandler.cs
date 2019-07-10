using RefactorTest.Domain;

namespace RefactorTest.ToRefactor
{
    public abstract class IFaxInstructionsHandler : IBaseInstructionsHandler
    {
        public abstract void ProcessReverseInstruction(PaymentInfo pay);
    }
}