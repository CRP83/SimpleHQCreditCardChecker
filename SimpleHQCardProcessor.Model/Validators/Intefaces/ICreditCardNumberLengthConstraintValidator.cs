using SimpleHQCardProcessor.Model.Data.Interfaces;

namespace SimpleHQCardProcessor.Model.Validation.Interfaces
{
    /// <summary>
    ///     This interface defines the validation method to validate the length of a credit card number.
    /// </summary>
    public interface ICreditCardNumberLengthConstraintValidator
    {
        /// <summary>
        ///     This method validates the Credit Card number for ensuring it has the right number of digits as per the <seealso cref="CardType"/>
        /// </summary>
        /// <param name="cardObject">A <seealso cref="ICard"/> object.</param>
        /// <param name="erroMessage">A error message to return to the client.</param>
        /// <returns>Boolean value as a result of validation.</returns>
        bool Validate(ICard cardObject, out string errorMessage);
    }
}
