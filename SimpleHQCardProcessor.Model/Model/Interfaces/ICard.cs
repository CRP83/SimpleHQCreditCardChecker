using System;

namespace SimpleHQCardProcessor.Model.Data.Interfaces
{
    /// <summary>
    ///  This interface defines the Credit Card attribues and behaviours.
    /// </summary>
    public interface ICard : IServiceProvider
    {
        /// <summary>
        ///  Credit card number.
        /// </summary>
        string CardNumber
        {
            get;
            set;
        }        

        /// <summary>
        ///  Credit card type.
        /// </summary>
        CardType CardType
        {
          get;
          set;
        }
    }
}
