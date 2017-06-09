
using SimpleHQCardProcessor.Model.Data;
using SimpleHQCardProcessor.Model.Data.Interfaces;
using SimpleHQCardProcessor.Model.Validation.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SimpleHQCardProcessor.Model.Validtors
{
    /// <summary>
    ///     This class implements the validation method to validate the length of a credit card number.
    /// </summary>
    internal class CreditCardNumberLengthConstraintValidator : ICreditCardNumberLengthConstraintValidator
    {

        #region ICreditCardNumberLengthConstraintValidator  Implementation

        public bool Validate(ICard cardObject, out string errorMessage)
        {
            //TODO:
            //In production we must avoid any hardcoding  and try to look for configuration possibilities.i.e.Resource files
            //XML, Database, Excel etc. 
            // 1) Ideally the length limits for each card type must be obtained from a encrypetd xml file for example.
            //This will help in securing the constratint and also in making limits easily configurable after deployment.
            // 2) The formatting strings must come from Resource files to enable localization.
            //This is pending in this implementation due to time constraint.

            errorMessage = string.Empty;
            bool isValid = false;
            KeyValuePair<bool, string> carLengthValidationResult = new KeyValuePair<bool, string>();
            string internalCardNumber = cardObject.CardNumber;
            switch (cardObject.CardType)
            {
                case CardType.AMEX:
                    {
                        carLengthValidationResult =
                            ValidateCardLength(internalCardNumber, new int[] { 15 });

                    }
                    break;
                case CardType.Discover:
                    {
                        carLengthValidationResult =
                            ValidateCardLength(internalCardNumber, new int[] { 16 });

                    }
                    break;
                case CardType.MasterCard:
                    {
                        carLengthValidationResult =
                            ValidateCardLength(internalCardNumber, new int[] { 16 });

                    }
                    break;
                case CardType.Visa:
                    {
                        int[] lengthLimit = new int[] { 13, 16 };
                        carLengthValidationResult =
                        ValidateCardLength(internalCardNumber, lengthLimit);

                    }
                    break;
                case CardType.Unknown:
                    {
                        carLengthValidationResult = new KeyValuePair<bool, string>(false, "Please select a valid Credit Card Type.");
                        break;
                    }
                default:
                    break;
            }
            isValid = carLengthValidationResult.Key;
            if (!isValid)
            {
                errorMessage = carLengthValidationResult.Value;
            }
            return isValid;
        }

        private KeyValuePair<bool, string> ValidateCardLength
           (string internalCardNumber, int[] expectedLengths)
        {
            string errorMessage = string.Empty;
            bool isValid = false;
            var invalidExpectedLength = int.MinValue;//Default Value

            //Compare the length to the limits and schek if there is a deviation.
            invalidExpectedLength = (from expectedLength in expectedLengths
                                     where internalCardNumber.Length != expectedLength
                                     select expectedLength).FirstOrDefault<int>();

            if (invalidExpectedLength != int.MinValue)
            {
                isValid = true;
            }
            else
            {
                errorMessage =
                    "Invalid: This credit card number has incorrect number of digits.";
            }
            return new KeyValuePair<bool, string>(isValid, errorMessage);
        }

        #endregion
    }
}
