using SimpleHQCardProcessor.Model;
using SimpleHQCardProcessor.Model.Data;
using SimpleHQCardProcessor.Model.Validation.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleHQ_CardProcessor
{
    public partial class simpleHQCardProcessorForm : Form
    {     
        
        Card m_CreditCard = null;
        /// <summary>
        /// To display a error icon.
        /// </summary>
        ErrorProvider formErrorProvider = null;

        public simpleHQCardProcessorForm()
        {
            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            m_CreditCard = new Card();
        }

        private void SimpleHQCardProcessorFormLoad(object sender, EventArgs e)
        {
            formErrorProvider = new ErrorProvider(this);
            maskedTextBoxCreditCardNumber.Mask = "0000000000000000";//16 digit mask.

            //Data binding concepts used for text and combo box.

            maskedTextBoxCreditCardNumber.DataBindings.Add("Text", m_CreditCard, "CardNumber");
            comboBoxCardType.DataSource = Enum.GetValues(typeof(CardType));
            comboBoxCardType.DataBindings.Add("SelectedItem", m_CreditCard, "CardType");
        }

        private void MaskedTextBoxCreditCardNumberValidated(object sender, EventArgs e)
        {

            //TODO: Made model properties more robust when setting values.
            if (!string.IsNullOrEmpty(m_CreditCard.CardNumber.Trim()))
            {
                ICreditCardValidator creditCardValidator = m_CreditCard.GetService(typeof(ICreditCardValidator)) as ICreditCardValidator;
                if (creditCardValidator != null)
                {
                    string errorMessage;
                    bool isValid = false;

                    isValid = creditCardValidator.ValidateCreditCard(m_CreditCard, out errorMessage);
                    if (!isValid)
                    {
                        labelFeedback.BackColor = Color.LightYellow;
                        labelFeedback.Text = "Feedback:" + Environment.NewLine + errorMessage;
                        formErrorProvider.SetError(labelFeedback, errorMessage);
                    }
                    else
                    {
                        this.labelFeedback.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                        labelFeedback.Text = "Feedback: Credit Card details were verified successfully.";
                        formErrorProvider.Clear();
                    }
                }
            }
            else
            {
                this.labelFeedback.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                labelFeedback.Text = string.Empty;
                formErrorProvider.Clear();
            }
        }

        private void ComboBoxCardTypeSelectionChangd(object sender, EventArgs e)
        {            
            if (!string.IsNullOrEmpty(m_CreditCard.CardNumber))
            {
                ICreditCardValidator creditCardValidator = m_CreditCard.GetService(typeof(ICreditCardValidator)) as ICreditCardValidator;
                if (creditCardValidator != null)
                {
                    string errorMessage;
                    bool isValid = false;

                    isValid = creditCardValidator.ValidateCreditCard(m_CreditCard, out errorMessage);
                    if (!isValid)
                    {
                        labelFeedback.BackColor = Color.LightYellow;
                        labelFeedback.Text = "Feedback:" + Environment.NewLine + errorMessage;
                        formErrorProvider.SetError(labelFeedback, errorMessage);
                    }

                    else
                    {
                        this.labelFeedback.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                        labelFeedback.Text = "Feedback: Credit Card details were verified successfully.";
                        formErrorProvider.Clear();
                    }
                }
            }
            else
            {
                this.labelFeedback.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                labelFeedback.Text = string.Empty;
                formErrorProvider.Clear();
            }
        }
    }
}
