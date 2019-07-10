using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorTest.Domain;
using RefactorTest.Logging;
using RefactorTest.ToRefactor;

namespace RefactorTest.Tests
{
    [TestClass]
    public class PaymentServiceTest
    {
        private DataServiceMock _dataService;
        private PaymentService _paymentService;
        
        [TestInitialize]
        public void Initialize()
        {
            Logger.Clear();

            _dataService = new DataServiceMock();

            _paymentService = new PaymentService();
        }

        [TestMethod]
        public void When_Called_With_Fax_PaymentMethod_And_Fax_ReversePaymentMethod()
        {
            var expectedLogEntries = new List<string>
            {
                "ProcessInstruction on Payment 1",
                "Generate PDF for instruction then send as e-mail for 1",
                "Released Payment 1",
                "ProcessReverseInstruction on Payment 1",
                "Generate PDF for reverseInstruction then send as e-mail for 1",
                "processPaymentReceipt on Payment 1",
                "Generate PDF for fax receipt then send as e-mail for 1"
            };
            
            _dataService.SetMockPendingPayments(new List<PaymentInfo> { new PaymentInfo { ID = 1, Method = PaymentMethod.Fax, ReversePaymentMethod = PaymentMethod.Fax } });

            _paymentService.ProcessPendingPayments(_dataService);
            
            var loggerOutput = Logger.GetLogEntries();

            AssertLogs(expectedLogEntries, loggerOutput);
        }

        [TestMethod]
        public void When_Called_With_Online_PaymentMethod_And_Online_ReversePaymentMethod()
        {
            var expectedLogEntries = new List<string>
            {
                "ProcessInstruction on Payment 2",
                "Generate Html for instruction then send as email for 2",
                "Released Payment 2",
                "ProcessReverseInstruction on Payment 2",
                "Generate Html for reverse instruction then send as email for 2"
            };

            _dataService.SetMockPendingPayments(new List<PaymentInfo> { new PaymentInfo { ID = 2, Method = PaymentMethod.Online, ReversePaymentMethod = PaymentMethod.Online } });
            _paymentService.ProcessPendingPayments(_dataService);

            var loggerOutput = Logger.GetLogEntries();

            AssertLogs(expectedLogEntries, loggerOutput);
        }

        [TestMethod]
        public void When_Called_With_WebEntry_PaymentMethod_And_WebEntry_ReversePaymentMethod()
        {
            var expectedLogEntries = new List<string>
            {
                "ProcessInstruction on Payment 3",
                "Released Payment 3",
                "ProcessReverseInstruction on Payment 3"
            };

            _dataService.SetMockPendingPayments(new List<PaymentInfo> { new PaymentInfo { ID = 3, Method = PaymentMethod.WebEntry, ReversePaymentMethod = PaymentMethod.WebEntry } });
            _paymentService.ProcessPendingPayments(_dataService);

            var loggerOutput = Logger.GetLogEntries();

            AssertLogs(expectedLogEntries, loggerOutput);
        }
        
        [TestMethod]
        public void When_Called_With_Fax_PaymentMethod_And_Online_ReversePaymentMethod()
        {
            var expectedLogEntries = new List<string>
            {
                "ProcessInstruction on Payment 4",
                "Generate PDF for instruction then send as e-mail for 4",
                "Released Payment 4",
                "ProcessReverseInstruction on Payment 4",
                "Generate Html for reverse instruction then send as email for 4",
                "processPaymentReceipt on Payment 4",
                "Generate PDF for fax receipt then send as e-mail for 4"
            };

            _dataService.SetMockPendingPayments(new List<PaymentInfo> { new PaymentInfo { ID = 4, Method = PaymentMethod.Fax, ReversePaymentMethod = PaymentMethod.Online} });
            _paymentService.ProcessPendingPayments(_dataService);

            var loggerOutput = Logger.GetLogEntries();

            AssertLogs(expectedLogEntries, loggerOutput);
        }

        private void AssertLogs(IReadOnlyList<string> expectedLogs, IReadOnlyList<string> actualLogs)
        {
            PrintLogs(expectedLogs, actualLogs);

            Assert.AreEqual(expectedLogs.Count, actualLogs.Count);

            for (int i = 0; i < expectedLogs.Count; i++)
            {
                Assert.AreEqual(expectedLogs[i], actualLogs[i]);
            }
        }

        private static void PrintLogs(IReadOnlyList<string> expectedLogs, IReadOnlyList<string> actualLogs)
        {
            Console.WriteLine("Expected Logs:");
            for (int i = 0; i < expectedLogs.Count; i++)
            {
                Console.WriteLine(expectedLogs[i]);
            }

            Console.WriteLine();

            Console.WriteLine("Actual Logs:");
            for (int i = 0; i < actualLogs.Count; i++)
            {
                Console.WriteLine(actualLogs[i]);
            }
        }
    }
}
