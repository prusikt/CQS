using RefactorTest.Domain;
using RefactorTest.Logging;

namespace RefactorTest.ToRefactor
{
    public class ProcessPayment : IInstructionHandler, IVisitor
    {
        private readonly IDataService _dataService;

        public ProcessPayment(IDataService dataService)
            => _dataService = dataService;
        

        private void UpdateCompleted(PaymentInfo pay)
            => _dataService.ReleasePayment(pay.ID);

        public void VisitPaymentByFax(PaymentByFax paymentByFax)
        {
            if (paymentByFax.IsReverse)
            {
                Logger.Log($"ProcessReverseInstruction on Payment {paymentByFax.PaymentInfo.ID}");
                FaxInstructionsHandler().ProcessReverseInstruction(paymentByFax.PaymentInfo);
            }
            else
            {
                FaxInstructionsHandler()
                    .ProcessInstruction(paymentByFax.PaymentInfo);
                UpdateCompleted(paymentByFax.PaymentInfo);
            }
        }

        public void VisitPaymentByOnline(PaymentByOnline paymentByOnline)
        {
            if (paymentByOnline.IsReverse)
            {
                Logger.Log($"ProcessReverseInstruction on Payment {paymentByOnline.Pay.ID}");
                BaseInstructionsHandler()
                    .ProcessInstruction(paymentByOnline.Pay, false);
            }
            else
            {
                BaseInstructionsHandler()
                    .ProcessInstruction(paymentByOnline.Pay, paymentByOnline.OriginalLeg);

                if (paymentByOnline.OriginalLeg)
                    UpdateCompleted(paymentByOnline.Pay);
            }
        }

        public void VisitPaymentByWebEntry(PaymentByWebEntry paymentByWebEntry)
        {
            if (paymentByWebEntry.IsReverse)
            {
                Logger.Log($"ProcessReverseInstruction on Payment {paymentByWebEntry.Pay.ID}");
            }
            else
            {
                UpdateCompleted(paymentByWebEntry.Pay);
            }

        }
    }
}