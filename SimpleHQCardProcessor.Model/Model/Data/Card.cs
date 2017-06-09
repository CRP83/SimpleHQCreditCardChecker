
using SimpleHQCardProcessor.Model.Data.Interfaces;
using SimpleHQCardProcessor.Model.Validation.Interfaces;
using SimpleHQCardProcessor.Model.Validation.Services;
using System;
using System.ComponentModel;

namespace SimpleHQCardProcessor.Model.Data
{
    /// <summary>
    ///  The Credit card entity.   
    /// </summary>
    public class Card : ICard, INotifyPropertyChanged
    {
        //TODO: Make this class abstract so that is extensible and create different types of CreditCards: Credit, Debit, Gift etc.
        #region Member Variales

        private ICreditCardValidator m_CreditCardValidator;
        private string m_CardNumber;
        private CardType m_CardType;
        private event PropertyChangedEventHandler m_NotifyOnPropertyChanged;

        #endregion

        #region Constructor

        public Card()
        {
            //TODO: Instantiate this sevcie using dependency injection to have loose coupling.
            m_CreditCardValidator = new CreditCardValidator();
        }
        #endregion

        #region Properties

        /// <summary>
        ///  The Credit Card Number.
        /// </summary>
        public string CardNumber
        {
            get
            {
                return m_CardNumber;
            }
            set
            {
                m_CardNumber = value;
                RaisePropertyChangedEvent("CardNumber");
            }
        }

        /// <summary>
        ///  The Credit Card Company Type.
        /// </summary>
        public CardType CardType
        {
            get
            {
                return m_CardType;
            }
            set
            {
                m_CardType = value;
            }
        }

        #endregion

        #region Events

        /// <summary>
        ///  This property allows clients to get notfied about property changes on this object.
        /// </summary>
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                m_NotifyOnPropertyChanged += value;
            }

            remove
            {
                m_NotifyOnPropertyChanged -= value;
            }
        }


        #endregion

        #region Private Metods

        /// <summary>
        ///  This event notifies clients about changes to the properties of this object.
        /// </summary>
        /// <param name="propertyName">The name of the proerty.</param>
        private void RaisePropertyChangedEvent(string propertyName)
        {
            if (m_NotifyOnPropertyChanged != null)
            {
                m_NotifyOnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region IServiceProvider Implemetation


        public object GetService(Type serviceType)
        {
            object serviceObject = null;
            if (typeof(ICreditCardValidator) == serviceType)
            {
                serviceObject = m_CreditCardValidator;
            }
            return serviceObject;
        }

        #endregion

    }
}


