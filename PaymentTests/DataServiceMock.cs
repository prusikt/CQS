using System.Collections.Generic;
using RefactorTest;
using RefactorTest.Domain;

namespace PaymentTests
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
            RefactorTest.Logging.Logger.Log(string.Format("Released Payment {0}", id));
        }
    }
}