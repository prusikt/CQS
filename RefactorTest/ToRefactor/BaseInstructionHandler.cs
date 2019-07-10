using System;
using RefactorTest.Domain;
using RefactorTest.Logging;

namespace RefactorTest.ToRefactor
{
    public class OnlineInstructionHandler : IBaseInstructionsHandler
    {
        public override void ProcessInstruction(PaymentInfo pay)
        {
            throw new NotImplementedException("Online instructions do not support this overload of ProcessInstruction");
        }

        public override void ProcessInstruction(PaymentInfo pay, bool originalLeg)
        {
            Logger.Log(OnlineInstructionBuilder.BuildOnlineInstructionFile(pay, originalLeg));
        }
    }
}