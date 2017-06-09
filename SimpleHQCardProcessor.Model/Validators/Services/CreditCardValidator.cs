using SimpleHQCardProcessor.Model.Data.Interfaces;
using SimpleHQCardProcessor.Model.Validation.Interfaces;
using SimpleHQCardProcessor.Model.Validtors;
using System.Text;

namespace SimpleHQCardProcessor.Model.Validation.Services
{
    /// <summary>
    ///     This is the main validation calss to be used when validating a credit card.
    /// </summary>
    public class CreditCardValidator : ICreditCardValidator
    {
        #region ICreditCardValidator Interface Implementation

        public bool ValidateCreditCard(ICard cardObject, out string errorMessage)
        {
            errorMessage = string.Empty;           
            bool isValid = false;

            if (cardObject != null && !string.IsNullOrEmpty(cardObject.CardNumber))

            {
                string lengthError;
                string beginsWithError;
                string luhnError;                

                //Use string builder to do optimal string concatenations as a recommended best practice.
                StringBuilder errorStringBuilder = new StringBuilder();
                errorStringBuilder.Append(cardObject.CardType.ToString() + " : " + cardObject.CardNumber + "");
                errorStringBuilder.AppendLine();

                #region First Level Validation - Number start and Length must be correct

                //Validate
                ICreditCardNumberBeginsWithConstraintValidator beginsWithValidator =
                    new CreditCardNumberBeginsWithConstraintValidator();
                isValid = beginsWithValidator.Validate(cardObject, out beginsWithError);
                //Prepare error string.
                PrepareErrorString(errorStringBuilder, beginsWithError);

                //Do further processing only if Number start is corrrect.
                if (isValid)
                {
                    //Validate
                    ICreditCardNumberLengthConstraintValidator lengthValidator
                    = new CreditCardNumberLengthConstraintValidator();
                    isValid = lengthValidator.Validate(cardObject, out lengthError);
                    //Prepare error string.
                    PrepareErrorString(errorStringBuilder, lengthError);
                }
                

                #endregion

                //Only if the number is valid as per constraints then the algorith must be run, else it can cause performnce issues.
                #region Second Level Validation - Luhn Algorithm               
                if (isValid)
                {
                    //Validate
                    ICreditCardLuhnAlgorithmValidator luhnValidator = new CreditCardLuhnAlgorithmValidator();
                    isValid = luhnValidator.Validate(cardObject, out luhnError);

                    //Prepare error string.
                    PrepareErrorString(errorStringBuilder, luhnError);
                }

                #endregion

                //Prepare final error string.
                errorMessage = errorStringBuilder.ToString();
            }
            return isValid;
        }

        private static void PrepareErrorString(StringBuilder stringbuilder, string lengthError)
        {
            //Only if there is an error append to the string builder.
            if (lengthError.Trim().Length > 0)
            {
                stringbuilder.Append(lengthError);
                stringbuilder.AppendLine();
            }
        }
        #endregion
    }
}
