using Zapper.Payment.Api.Models;

namespace Zapper.Payment.Api.Extensions {

    public static class TransactionExtensions {

        public static int CalculateTipTotal(this Transaction transaction) {

            if (!transaction.TipPercentage.HasValue) {
                return 0;
            }

            return transaction.Amount * transaction.TipPercentage.Value / 100;
        }
    }
}