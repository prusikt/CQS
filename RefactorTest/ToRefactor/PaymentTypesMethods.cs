using RefactorTest.Domain;

namespace RefactorTest.ToRefactor
{
    internal static class PaymentTypesMethods
    {
        public static bool IsFax(this PaymentMethod paymentMethod)
            => paymentMethod == PaymentMethod.Fax;

        public static bool IsNull(this PaymentMethod? paymentMethod)
            => paymentMethod == null;
    }
}