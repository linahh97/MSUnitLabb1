using System;
using System.Collections.Generic;
using System.Linq;

namespace MSUnitLabb1
{
    public partial class Customer : Login
    {
        List<string> Transactions = new List<string>();            

        public void SaveTransaction(float moneyAmount, Accounts transferAccount, bool plusOrMinus, string changedTransfer)
        {
            Transcation savedTransaction = new Transcation
            {
                TimeOfTransfer = DateTime.Now,
                PlusOrMinus = plusOrMinus,
                TransferAccount = transferAccount,
                MoneyAmount = moneyAmount,
                ChangedTransfer = changedTransfer,
                User = this
            };
            BankController.queuedTransactions.Enqueue(savedTransaction);
        }

        public void SaveCalculations(float sendAmount, float recieveAmount, Accounts fromAccount, Accounts toAccount)
        {
            Calculation savedCalculation = new Calculation
            {
                RecieveAmount = recieveAmount,
                SendAmount = sendAmount,
                SendAccount = fromAccount,
                RecieveAccount = toAccount
            };
            BankController.queuedCalculations.Enqueue(savedCalculation);
        }

        public void ListTransaction(Transcation transcation)
        {
            string savedTransfer = transcation.SavedTransfer();
            Transactions.Add(savedTransfer);
        }

        public void ShowTransactions()
        {
            foreach (string transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
            if (Transactions.Count == 0)
            {
                Console.WriteLine("Inga transaktioner ännu genomförts");
            }
        }

        [Obsolete("Use the normal CreateAccount method instead!", true)]
        public void CreateSavingsAccount()
        {
            Console.Write("Namnge sparkonto: ");
            string accountName = Console.ReadLine();
            float accountAm = 0;
            Console.WriteLine("Svenska krona: kr | US dollar: dollar | Brittisk pund: pund | Euro: euro ");
            Console.Write("Välj valuta: ");
            string chooseCurrency = Console.ReadLine();
            Currency currencyEnum = (Currency)Enum.Parse(typeof(Currency), chooseCurrency);
            Accounts createAccounts = new Accounts(accountName, accountAm, chooseCurrency);
            createAccounts.IsSavings = true;
            ListOfAccounts.Add(createAccounts);
            Console.WriteLine(createAccounts._Name + " " + createAccounts._Balance + " " + createAccounts._Currency);
        }

        public void DepositMoney()
        {
            ShowAccounts();
            Console.Write("Välj ett konto att sätta in pengar på: ");
            string depositText = Console.ReadLine();
            Accounts depositAccount = ListOfAccounts.Find(s => s._Name == depositText);
            while (depositAccount == null)
            {
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                depositText = Console.ReadLine();
                depositAccount = ListOfAccounts.Find(s => s._Name == depositText);
            }
            Console.Write("Skriv hur mycket pengar du vill sätta in: ");
            float moneyAmount = 0;
            bool isException = false;
            do
            {
                try
                {
                    moneyAmount = float.Parse(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                    isException = true;
                }
            }
            while (isException);

            if (depositAccount.IsSavings == true)
            {
                decimal IntrestRate = 0.01M;
                decimal YearlyAmount = IntrestRate * (decimal)moneyAmount;
                Console.WriteLine("Om räntan är " + IntrestRate * 100 + "% kommer du att få en årlig bonus på: " + Math.Round(YearlyAmount, 2));
            }

            SaveCalculations(moneyAmount, 0, null, depositAccount);
            SaveTransaction(moneyAmount, depositAccount, true, "Insättning på bankomat\t\t");
            Console.WriteLine("Uppdatering går igenom om 15 sekunder!");
        }

        public void WithdrawMoney()
        {
            ShowAccounts();
            Console.Write("Välj ett konto att ta ut pengar ifrån: ");
            string withdrawText = Console.ReadLine();
            Accounts withdrawAccount = ListOfAccounts.Find(s => s._Name == withdrawText);
            while (withdrawAccount == null)
            {
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                withdrawText = Console.ReadLine();
                withdrawAccount = ListOfAccounts.Find(s => s._Name == withdrawText);
            }
            Console.Write("Skriv hur mycket pengar vill du ta ut: ");
            float moneyAmount = 0;
            bool isException = false;
            do
            {
                try
                {
                    moneyAmount = float.Parse(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                    isException = true;
                }
            }
            while (isException);

            SaveCalculations(moneyAmount, 0, withdrawAccount, null);
            SaveTransaction(moneyAmount, withdrawAccount, false, "Uttag från bankomat\t\t");
            Console.WriteLine("Uppdatering går igenom om 15 sekunder!");
        }

        public float InterestAmount(Accounts savAcc)
        {
            bool isException;
            decimal IntrestRate = 0.01M;
            decimal InsertedAmount = 0;
            Console.Write("Skriv hur mycket vill du sätta in: ");
            do
            {
                try
                {
                    InsertedAmount = Convert.ToDecimal(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                    isException = true;
                }

            } while (isException);

            decimal YearlyAmount = IntrestRate * InsertedAmount;
            Console.WriteLine("Om räntan är " + IntrestRate * 100 + "% kommer du att få en årlig bonus på: " + Math.Round(YearlyAmount, 2) + savAcc._Currency);
            return (float)InsertedAmount;
        }

        public void ChangePassword()
        {
            Console.WriteLine("Ditt lösenord måste innehålla både siffror och bokstäver, samt innehålla minst 8 tecken ");
            Console.Write("Ange ett nytt Lösenord: ");
            string passwordCreated = Console.ReadLine();

            while (!passwordCreated.Any(char.IsLetter) || !passwordCreated.Any(char.IsNumber))
            {
                Console.WriteLine("Ditt lösenord måste innehålla både siffror och bokstäver");
                Console.Write("Var god ange ett nytt lösenord: ");
                passwordCreated = Console.ReadLine();
            }

            while (passwordCreated.Length < 8)
            {
                Console.WriteLine("Lösenordet var för kort, det måste innehålla minst 8 tecken.");
                Console.Write("Var god ange ett nytt lösenord: ");
                passwordCreated = Console.ReadLine();
            }
            Password = passwordCreated;
        }
    }
}
