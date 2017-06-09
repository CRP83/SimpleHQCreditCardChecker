using SimpleHQCardProcessor.Model.Data.Interfaces;
using SimpleHQCardProcessor.Model.Validation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleHQCardProcessor.Model.Validtors
{
    /// <summary>
    ///     This interface defines the validation to be asper the the Luhns Algorithm.
    /// </summary>
    internal class CreditCardLuhnAlgorithmValidator : ICreditCardLuhnAlgorithmValidator
    {
        #region ICreditCardLuhnAlgorithmValidator Implementaion 
        public bool Validate(ICard cardObject, out string errorMessage)
        {
            bool isValid = false;
            string cardNumber = cardObject.CardNumber.Trim();
            errorMessage = string.Empty;
            //Numbers to be Double: 97531004
            //Numbers not to be Doubled: 4842468

            //Pull out the last digit as it will only get involved in the final adddition.
            int lastDigit = int.Parse(cardNumber.Substring(cardNumber.Length - 1, 1));
            //Create a number excluding the last but one, credit card digits.
            string crediCardNumberWithLastDigitExcluded = cardNumber.Substring(0, cardNumber.Length - 1);

            List<int> finalListOfDigits = new List<int>();
            //Create a array of all digits in the new Credit card number.
            char[] digitsAsCharacters = crediCardNumberWithLastDigitExcluded.ToArray();
            char[] reversedDigitsAsCharacters =  digitsAsCharacters.Reverse<char>().ToArray<char>();
            
            for (int digitCounter = 0; digitCounter < reversedDigitsAsCharacters.Length; digitCounter = digitCounter + 2)
            {
                int number = int.Parse(reversedDigitsAsCharacters[digitCounter].ToString());
                 number = number * 2;
                // If the number is made up of 2-digts, then split and add them to the collection.
                if (number >= 10)
                {
                    int secondDigit = int.MaxValue;
                    int firstDigit = Math.DivRem(number, 10, out secondDigit);
                    finalListOfDigits.Add(firstDigit + secondDigit);
                }

                else
                {
                    finalListOfDigits.Add(number);
                }
            }

            for (int digitCounter = 1; digitCounter < reversedDigitsAsCharacters.Length; 
                digitCounter = digitCounter + 2)
            {
                int number = int.Parse(reversedDigitsAsCharacters[digitCounter].ToString());
                finalListOfDigits.Add(number);
            }

           
            //finally sump up all the formed digits with the last digit.
            int finalValue = finalListOfDigits.Sum() + lastDigit;
            //Test using the modulo operator if the number is valid.
            if (finalValue % 10 == 0)
            {
                isValid = true;
            }
            else
            {
                errorMessage = "Invalid Credit CardNumber number sequence.";
            }
            return isValid;
        }

        #endregion
    }
}
