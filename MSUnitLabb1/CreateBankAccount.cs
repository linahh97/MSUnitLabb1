using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSUnitLabb1
{
    public class CreateBankAccount
    {
        // Properties from Accounts class
        private string name;
        private int balance;
        private string currency;
        private bool isSavings;

        public string _Name { get => name; set => name = value; }
        public int _Balance { get => balance; set => balance = value; }
        public string _Currency { get => currency; set => currency = value; }
        public bool IsSavings { get => isSavings; set => isSavings = value; }

        public CreateBankAccount(string _name, int _balance, string _currency)
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
        public List<CreateBankAccount> ListOfAccounts = new List<CreateBankAccount>();
        public void AddAccounts(CreateBankAccount _Account)
        {
            ListOfAccounts.Add(_Account);
        }
        public string CreateSavingsAccount(string accountName, int accountAm, string chooseCurrency)
        {
            Currency currencyEnum = (Currency)Enum.Parse(typeof(Currency), chooseCurrency);
            CreateBankAccount createAccounts = new CreateBankAccount(accountName, accountAm, chooseCurrency);
            createAccounts.IsSavings = true;
            ListOfAccounts.Add(createAccounts);
            Console.WriteLine(createAccounts._Name + " " + createAccounts._Balance + " " + createAccounts._Currency);
            return "valid";
        }
    }
}
