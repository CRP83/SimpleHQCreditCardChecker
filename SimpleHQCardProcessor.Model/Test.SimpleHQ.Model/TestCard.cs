using System;
using NUnit.Framework;
using SimpleHQCardProcessor.Model.Data;
using SimpleHQCardProcessor.Model.Validation.Interfaces;

namespace Test.SimpleHQ.Model
{
    [TestFixture]
    public class TestCard
    {
        [Test]
        [TestCase("378282246310005", CardType.AMEX)]
        [TestCase("6011111111111117", CardType.Discover)]
        [TestCase("5105105105105100", CardType.MasterCard)]
        [TestCase("4111111111111111", CardType.Visa)]
        public void ValidateValidCreditCardNumbers(string cardNumber, CardType cardType)
        {
            Card creditCard = new Card() { CardNumber = cardNumber , CardType = cardType};
            ICreditCardValidator creditCardValidator = creditCard.GetService(typeof(ICreditCardValidator))
                as ICreditCardValidator;
            bool isValid = false;
            string errorMessage = string.Empty;
            if (creditCardValidator != null)
            {
                isValid = creditCardValidator.ValidateCreditCard(creditCard, out errorMessage);
            }
            NUnit.Framework.Assert.False(isValid, $"Failed for {creditCard.CardNumber} with type {creditCard.CardType}");
            NUnit.Framework.Assert.IsEmpty(errorMessage, $"Failed for {creditCard.CardNumber} with type {creditCard.CardType}");

        }


        [Test]
        [TestCase("378282246310015", CardType.AMEX)]
        [TestCase("6011111111111127", CardType.Discover)]
        [TestCase("5105105105105110", CardType.MasterCard)]
        [TestCase("4111111111111121", CardType.Visa)]
        public void ValidateInValidCreditCardNumbers(string cardNumber, CardType cardType)
        {
            Card creditCard = new Card() { CardNumber = cardNumber, CardType = cardType };
            ICreditCardValidator creditCardValidator = creditCard.GetService(typeof(ICreditCardValidator))
                as ICreditCardValidator;
            bool isValid = false;
            string errorMessage = string.Empty;
            if (creditCardValidator != null)
            {
                isValid = creditCardValidator.ValidateCreditCard(creditCard, out errorMessage);
            }
            NUnit.Framework.Assert.False(isValid, $"Failed for {creditCard.CardNumber} with type {creditCard.CardType}");
            NUnit.Framework.Assert.IsEmpty(errorMessage, $"Failed for {creditCard.CardNumber} with type {creditCard.CardType}");

        }

    }
}
