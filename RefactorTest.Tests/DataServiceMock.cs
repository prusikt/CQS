using System.Collections.Generic;
using RefactorTest.Domain;

namespace RefactorTest.Tests
{
    public class DataServiceMock : IDataService
    {
        private List<PaymentInfo> _mockPayments;
        public void SetMockPendingPayments(List<PaymentInfo> mockPayments)
        {
            _mockPayments = mockPayments;
        }

        public List<PaymentInfo> GetPendingPayments()
        {
            return _mockPayments;
        }

        public void ReleasePayment(int id)
        {
            Logging.Logger.Log(string.Format("Released Payment {0}", id));
        }
    }
}