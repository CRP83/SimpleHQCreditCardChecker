using SimpleHQCardProcessor.Model.Data.Interfaces;

namespace SimpleHQCardProcessor.Model.Validation.Interfaces
{
    /// <summary>
    ///     This is the main validation interace to be used when validating a credit card.
    /// </summary>
    public interface ICreditCardValidator
    {
        /// <summary>
        ///   This method validates the credit card object.
        /// </summary>
        /// <param name="cardObject"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        bool ValidateCreditCard(ICard cardObject, out string errorMessage);
    }
}
