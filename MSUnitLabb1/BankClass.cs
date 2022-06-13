using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSUnitLabb1
{
    public class BankClass
    {
        // Method from Customer2 class
        public static bool ChangePassword(string Password)
        {
            if (!Password.Any(char.IsLetter) || !Password.Any(char.IsNumber))
            {
                return false;
            }
            else if (Password.Length < 8)
            {
                return false;
            }
            return true;
        }


        // Properties from Accounts class
        private string name;
        private int balance;
        private string currency;
        private bool isSavings;

        public string _Name { get => name; set => name = value; }
        public int _Balance { get => balance; set => balance = value; }
        public string _Currency { get => currency; set => currency = value; }
        public bool IsSavings { get => isSavings; set => isSavings = value; }

        public BankClass(string _name, int _balance, string _currency)
        {
            name = _name;
            balance = _balance;
            currency = _currency;
        }
    }

    public class CreateAccount
    {
        // From Customer class
        public enum Currency
        {
            SEK,
            USD,
            GBP,
            EUR
        }

        // From Account class
        public List<BankClass> ListOfAccounts = new List<BankClass>();
        public void AddAccounts(BankClass _Account)
        {
            ListOfAccounts.Add(_Account);
        }
        public string CreateSavingsAccount(string accountName, int accountAm, string chooseCurrency)
        {
            Currency currencyEnum = (Currency)Enum.Parse(typeof(Currency), chooseCurrency);
            BankClass createAccounts = new BankClass(accountName, accountAm, chooseCurrency);
            createAccounts.IsSavings = true;
            ListOfAccounts.Add(createAccounts);
            Console.WriteLine(createAccounts._Name + " " + createAccounts._Balance + " " + createAccounts._Currency);
            return "valid";
        }
    }

    public class Withdraw
    {
        // Customer 2 class
        List<string> Transactions = new List<string>();

        public void SaveTransaction(float moneyAmount, bool plusOrMinus, string changedTransfer)
        {
            Transcation savedTransaction = new Transcation
            {
                PlusOrMinus = plusOrMinus,
                MoneyAmount = moneyAmount,
                ChangedTransfer = changedTransfer,
            };
            BankController.queuedTransactions.Enqueue(savedTransaction);
        }

        public List<BankClass> ListOfAccounts = new List<BankClass>();

        public int WithdrawMoney(BankClass withdrawAccount, int money)
        {
            BankClass a1 = new BankClass("Spar", 50000, "SEK");
            ListOfAccounts.Add(a1);

            string withdrawText = "Spar";
            withdrawAccount = ListOfAccounts.Find(s => s._Name == withdrawText);
            while (a1 == null)
            {
                withdrawAccount = ListOfAccounts.Find(s => s._Name == withdrawText);
                return 0;
            }
            int moneyAmount = 0;
            bool isException = false;
            do
            {
                try
                {
                    moneyAmount = money;
                    Console.WriteLine("no");
                    isException = false;
                }
                catch (Exception)
                {
                    isException = true;
                }
            }
            while (isException);
            SaveTransaction(moneyAmount, false, "Uttag från bankomat\t\t");
            return withdrawAccount._Balance -= moneyAmount;
        }
    }
}
