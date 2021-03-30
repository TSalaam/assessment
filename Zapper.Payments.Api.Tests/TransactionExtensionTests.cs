using NUnit.Framework;

using Zapper.Payment.Api.Extensions;
using Zapper.Payment.Api.Models;

namespace Zapper.Payments.Api.Tests {

    public class Tests {

        [Test]
        public void TransactionExtension_TipAmount_Is_Zero_If_Tip_Percent_Null() {

            var transaction = new Transaction {
                Amount = 100
            };

            Assert.AreEqual(0, transaction.CalculateTipTotal());
        }

        [Test]
        public void TransactionExtension_TipAmount_Calculates_Correctly_For_Percentage() {

            var transaction = new Transaction {
                Amount = 160,
                TipPercentage = 10
            };

            Assert.AreEqual(16, transaction.CalculateTipTotal());
        }
    }
}