namespace SimpleHQ_CardProcessor
{
    partial class simpleHQCardProcessorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCardNumber = new System.Windows.Forms.Label();
            this.labelCardType = new System.Windows.Forms.Label();
            this.comboBoxCardType = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxCreditCardNumber = new System.Windows.Forms.MaskedTextBox();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCardNumber
            // 
            this.labelCardNumber.AutoSize = true;
            this.labelCardNumber.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCardNumber.Location = new System.Drawing.Point(12, 62);
            this.labelCardNumber.Name = "labelCardNumber";
            this.labelCardNumber.Size = new System.Drawing.Size(84, 13);
            this.labelCardNumber.TabIndex = 0;
            this.labelCardNumber.Text = "Card Number:";
            // 
            // labelCardType
            // 
            this.labelCardType.AutoSize = true;
            this.labelCardType.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCardType.Location = new System.Drawing.Point(12, 23);
            this.labelCardType.Name = "labelCardType";
            this.labelCardType.Size = new System.Drawing.Size(69, 13);
            this.labelCardType.TabIndex = 1;
            this.labelCardType.Text = "Card Type:";
            // 
            // comboBoxCardType
            // 
            this.comboBoxCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCardType.FormattingEnabled = true;
            this.comboBoxCardType.Location = new System.Drawing.Point(108, 23);
            this.comboBoxCardType.Name = "comboBoxCardType";
            this.comboBoxCardType.Size = new System.Drawing.Size(110, 21);
            this.comboBoxCardType.TabIndex = 3;
            this.comboBoxCardType.Validated += new System.EventHandler(this.ComboBoxCardTypeSelectionChangd);
            // 
            // maskedTextBoxCreditCardNumber
            // 
            this.maskedTextBoxCreditCardNumber.Location = new System.Drawing.Point(108, 62);
            this.maskedTextBoxCreditCardNumber.Mask = "0000000000000000";
            this.maskedTextBoxCreditCardNumber.Name = "maskedTextBoxCreditCardNumber";
            this.maskedTextBoxCreditCardNumber.Size = new System.Drawing.Size(109, 20);
            this.maskedTextBoxCreditCardNumber.TabIndex = 4;
            this.maskedTextBoxCreditCardNumber.Validated += new System.EventHandler(this.MaskedTextBoxCreditCardNumberValidated);
            // 
            // labelFeedback
            // 
            this.labelFeedback.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelFeedback.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelFeedback.Location = new System.Drawing.Point(2, 103);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(310, 117);
            this.labelFeedback.TabIndex = 6;
            // 
            // simpleHQCardProcessorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(381, 249);
            this.Controls.Add(this.labelFeedback);
            this.Controls.Add(this.maskedTextBoxCreditCardNumber);
            this.Controls.Add(this.comboBoxCardType);
            this.Controls.Add(this.labelCardType);
            this.Controls.Add(this.labelCardNumber);
            this.Name = "simpleHQCardProcessorForm";
            this.Text = "SimpleHQ  Card Processor";
            this.Load += new System.EventHandler(this.SimpleHQCardProcessorFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCardNumber;
        private System.Windows.Forms.Label labelCardType;
        private System.Windows.Forms.ComboBox comboBoxCardType;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCreditCardNumber;
        private System.Windows.Forms.Label labelFeedback;
    }
}

