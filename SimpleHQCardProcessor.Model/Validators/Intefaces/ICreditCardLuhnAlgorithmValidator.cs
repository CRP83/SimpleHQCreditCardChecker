

using SimpleHQCardProcessor.Model.Data.Interfaces;

namespace SimpleHQCardProcessor.Model.Validation.Interfaces
{

    /// <summary>
    ///     This interface defines the validation to be asper the the Luhns Algorithm.
    /// </summary>
    public interface ICreditCardLuhnAlgorithmValidator
    {
        /// <summary>
        ///     This method validates the Credit Card for number validity.
        /// </summary>
        /// <param name="cardObject">A <seealso cref="ICard"/> object.</param>
        /// <param name="erroMessage">A error message to return to the client.</param>
        /// <returns>Boolean value as a result of validation.</returns>
        bool Validate(ICard  cardObject, out string erroMessage);
    }
}
