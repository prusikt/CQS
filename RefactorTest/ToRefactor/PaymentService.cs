using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RefactorTest.Domain;
using RefactorTest.Logging;

namespace RefactorTest.ToRefactor
{
    public class PaymentService
    {
        public void ProcessPendingPayments(IDataService dataService)
        {
            try
            {
                List<PaymentInfo> payments = dataService.GetPendingPayments();

                var instructionHandlerFactory = new InstructionHandlerFactory(dataService);

                foreach (var pay in payments)
                {
                    instructionHandlerFactory.ProcessInstruction(pay);
                }
            }
            catch (Exception exPendingPayments)
            {
                Logger.Log("Exception: " + exPendingPayments.Message);
            }
        }
    }
}