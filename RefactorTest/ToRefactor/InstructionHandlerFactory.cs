using System.Data;
using RefactorTest.Domain;
using RefactorTest.Logging;

namespace RefactorTest.ToRefactor
{
    public class InstructionHandlerFactory : IInstructionHandler
    {
        private readonly ProcessPayment processPayment;

        public InstructionHandlerFactory(IDataService dataService)
            => processPayment = new ProcessPayment(dataService);
        
        public void ProcessInstruction(PaymentInfo paymentInfo)
        {
            Log($"ProcessInstruction on Payment {paymentInfo.ID}");
            ProcessPaymentType(paymentInfo, true, false);
            if (paymentInfo.ReversePaymentMethod.IsNull()) return;
            ProcessPaymentType(paymentInfo, false, true);
            if (paymentInfo.Method.IsFax())
                ProcessPaymentReceipt(paymentInfo);
        }

        private void ProcessPaymentType(PaymentInfo paymentInfo, bool isOriginal, bool isReverse)
        {
            PaymentType paymentType = PaymentType(paymentInfo, isOriginal, isReverse);
            paymentType?.Accept(processPayment);
        }

        private static PaymentType PaymentType(PaymentInfo paymentInfo,bool isOriginalLeg, bool isReverse)
        {
            switch (isReverse ? SwitchOn(paymentInfo) : paymentInfo.Method)
            {
                case PaymentMethod.Fax:
                    return  new PaymentByFax(paymentInfo, isReverse);
                case PaymentMethod.Online:
                    return new PaymentByOnline(paymentInfo, isOriginalLeg, isReverse);
                case PaymentMethod.WebEntry:
                    return new PaymentByWebEntry(paymentInfo, isReverse);
            }

            return null;
        }

        private static PaymentMethod? SwitchOn(PaymentInfo paymentInfo)
        {
            var reversePaymentMethod = paymentInfo.ReversePaymentMethod;
            return reversePaymentMethod is null ? 
                paymentInfo.Method : 
                paymentInfo.ReversePaymentMethod;
        }

        private void Log(string text)
            => Logger.Log(text);
        
        private void ProcessPaymentReceipt(PaymentInfo pay)
        {
            Log($"processPaymentReceipt on Payment {pay.ID}");
            // Call the conversion method and get back the path to the converted PDF document
            Log($"Generate PDF for fax receipt then send as e-mail for {pay.ID}");
        }
    }
}