using SimpleHQCardProcessor.Model.Data;
using SimpleHQCardProcessor.Model.Data.Interfaces;
using SimpleHQCardProcessor.Model.Validation.Interfaces;
using System.Linq;

namespace SimpleHQCardProcessor.Model.Validtors
{

    /// <summary>
    ///     This interface defines the validation method to validate the beginning numbers for a credit card.
    /// </summary>
    internal class CreditCardNumberBeginsWithConstraintValidator : ICreditCardNumberBeginsWithConstraintValidator
    {
        //TODO:
        //In production we must avoid any hardcoding  and try to look for configuration possibilities.i.e.Resource files
        //XML, Database, Excel etc. 
        // 1) Ideally the length limits for each card type must be obtained from a encrypetd xml file for example.
        //This will help in securing the constratint and also in making limits easily configurable after deployment.
        // 2) The formatting strings must come from Resource files to enable localization.
        //This is pending in this implementation due to time constraint.


        public bool Validate(ICard cardObject, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool isValid = false;
            string internalCardNumber = cardObject.CardNumber;

            switch (cardObject.CardType)
            {
                case CardType.AMEX:
                    {
                        isValid = ValidateCardStartingNumber(internalCardNumber,
                            new string[] { "34", "37" });
                        if (!isValid)
                        {
                            errorMessage = " Credit Card number does not begin with valid values.";
                        }

                    }
                    break;
                case CardType.Discover:
                    {
                        isValid = ValidateCardStartingNumber(internalCardNumber,
                            new string[] { "6011" });
                        if (!isValid)
                        {
                            errorMessage = " Credit Card number does not begin with valid values.";
                        }
                        
                    }
                    break;
                case CardType.MasterCard:
                    {
                        isValid = ValidateCardStartingNumber(internalCardNumber,
                           new string[] { "51", "52", "53", "54", "55" });
                        if (!isValid)
                        {
                            errorMessage = " Credit Card number does not begin with valid values.";
                        }
                    }
                    break;
                case CardType.Visa:
                    {
                        isValid = ValidateCardStartingNumber(internalCardNumber,
                           new string[] { "4" });
                        if (!isValid)
                        {
                            errorMessage = " Credit Card number does not begin with valid values.";
                        }
                    }
                    break;
                case CardType.Unknown:
                    {
                        errorMessage = "Please select a valid Credit Card Type.";
                        break;
                    }
                default:
                    {
                        //Ideally throw an execption here to detect if a new enum is added but not handled in validations. before issue comes from production.
                    }
                    break;
            }
            return isValid;
        }

        private bool ValidateCardStartingNumber
          (string internalCardNumber, string[] startsWithDigits)
        {
            string errorMessage = string.Empty;
            bool isValid = false;

            var result = (from startsWithDigit in startsWithDigits
                          where internalCardNumber.StartsWith(startsWithDigit)
                          select startsWithDigit).FirstOrDefault<string>();
            if (result != null )
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
