namespace RefactorTest.ToRefactor
{
    public abstract class IInstructionHandler
    {
        internal IBaseInstructionsHandler BaseInstructionsHandler()
            => new OnlineInstructionHandler();

        internal IFaxInstructionsHandler FaxInstructionsHandler()
            => new FaxInstructionHandler();

    }
}