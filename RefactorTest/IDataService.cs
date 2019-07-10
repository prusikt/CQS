using System.Collections.Generic;
using RefactorTest.Domain;

namespace RefactorTest
{
    public interface IDataService
    {
        List<PaymentInfo> GetPendingPayments();
        void ReleasePayment(int id);
    }
}