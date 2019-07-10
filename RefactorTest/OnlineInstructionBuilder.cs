using RefactorTest.Domain;

namespace RefactorTest
{
    public static class OnlineInstructionBuilder
    {
        public static string BuildOnlineInstructionFile(PaymentInfo pay, bool originalLeg)
            => originalLeg
                ? $"Generate Html for instruction then send as email for {pay.ID}"
                : $"Generate Html for reverse instruction then send as email for {pay.ID}";
        
    }
}