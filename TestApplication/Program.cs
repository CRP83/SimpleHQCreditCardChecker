using SimpleHQCardProcessor.Model.Data;
using SimpleHQCardProcessor.Model.Validation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        //TODO: Logic to make validate commandline arguements can be made more robust in production using
        //limits, pattern and other validation checks.
        static void Main(string[] args)
        {
            ProcessCreditCards(args);
        }


        #region Processing & Validation Logic

        private static void ProcessCreditCards(string[] args)
        {
            string[] commandLineArguements = args;

            string creditCardNumber = string.Empty;
            Console.WriteLine("**************************Simple HQ Credit Card Valdiator******************");
            Console.WriteLine(Environment.NewLine);

            //The while loop gives a infinite loop for processing the entered credit card numbers.
            while (true)
            {
                if (commandLineArguements.Length < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Please enter the credit card number(s) to be validated.");
                    Console.WriteLine("Tool Usage e.g.: TestApplication.exe 4111111111111111");
                    Console.WriteLine("Tool Usage (multiple credit cards)  e.g.: TestApplication.exe \"4111111111111111\", \"4012888888881881\"");
                    Console.WriteLine(Environment.NewLine);

                    creditCardNumber = Console.ReadLine();
                    //TODO: Validate for input params in production code.
                    Validate(creditCardNumber.Trim());

                }
                else if (commandLineArguements.Length >= 1)
                {
                    foreach (var ccNumber in args)
                    {
                        Validate(ccNumber.Trim());
                    }
                    commandLineArguements = new string[] { };
                }
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("**************************Simple HQ Credit Card Valdiator****************");
                continue;
            }
        }

        private static void Validate(string creditCardNumber)
        {
            Card card = GetCreditCardObject(creditCardNumber);
            ValidateCreditCard(card);
        }

        private static Card GetCreditCardObject(string creditCardNumber)
        {
            Card card = new Card();
            card.CardNumber = creditCardNumber;

            if (creditCardNumber.StartsWith("34") || creditCardNumber.StartsWith("37"))
            {
                card.CardType = CardType.AMEX;
            }
            else if (creditCardNumber.StartsWith("6011"))
            {
                card.CardType = CardType.Discover;
            }
            else if (creditCardNumber.StartsWith("51") || creditCardNumber.StartsWith("52")
                || creditCardNumber.StartsWith("53")
                || creditCardNumber.StartsWith("54")
                || creditCardNumber.StartsWith("55"))
            {
                card.CardType = CardType.MasterCard;
            }
            else if (creditCardNumber.StartsWith("4"))
            {
                card.CardType = CardType.Visa;
            }
            else
            {
                card.CardType = CardType.Unknown;
            }

            return card;
        }

        private static void ValidateCreditCard(Card card)
        {
            if (card.CardType != CardType.Unknown)
            {
                ICreditCardValidator creditCardValidator = card.GetService(typeof(ICreditCardValidator)) as ICreditCardValidator;
                if (creditCardValidator != null)
                {
                    string errorMessage;
                    bool isValid = false;

                    isValid = creditCardValidator.ValidateCreditCard(card, out errorMessage);
                    if (!isValid)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{card.CardType}: {card.CardNumber} (Invalid)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{card.CardType}: {card.CardNumber} (Valid)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Unknown: {card.CardNumber} (Invalid)");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        #endregion
    }
}
