using System;
using RefactorTest.Domain;
using RefactorTest.Logging;

namespace RefactorTest.ToRefactor
{
    public class FaxInstructionHandler : IFaxInstructionsHandler
    {
        public override void ProcessInstruction(PaymentInfo pay)
        {
            Logger.Log(string.Format("Generate PDF for instruction then send as e-mail for {0}", pay.ID));
        }

        public override void ProcessInstruction(PaymentInfo pay, bool originalLeg)
        {
            throw new NotImplementedException("Fax instruction handler does not support this overload of ProcessInstruction");
        }

        public override void ProcessReverseInstruction(PaymentInfo pay)
        {
            Logger.Log(string.Format("Generate PDF for reverseInstruction then send as e-mail for {0}", pay.ID));
        }
    }
}