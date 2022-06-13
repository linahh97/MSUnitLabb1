using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitLabb1
{
    public partial class Customer : Login
    {
        public List<Accounts> ListOfAccounts = new List<Accounts>();

        public void AddAccounts(Accounts _Account)
        {
            ListOfAccounts.Add(_Account);
        }

        public Customer(string _userName, string _password)
        {
            UserName = _userName;
            Password = _password;
        }

        public void ShowAccounts()
        {
            if (ListOfAccounts.Count > 0)
            {
                foreach (var item in ListOfAccounts)
                {
                    item.PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("Du har inga konton...");
            }

        }

        public void ShowAccountsNames()
        {
            foreach (var item in ListOfAccounts)
            {
                item.PrintAccountName();
            }
        }

        public void TransferAccounts()
        {
            Console.Write("Välj ett konto att föra över pengar från: ");
            string sendAccount = Console.ReadLine();
            Accounts account = ListOfAccounts.Find(s => s._Name == sendAccount);
            while (account == null)
            {
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                sendAccount = Console.ReadLine();
                account = ListOfAccounts.Find(s => s._Name == sendAccount);
            }
            Console.Write("Välj sen ett konto att föra över pengar till: ");
            string recieveAccount = Console.ReadLine();
            Accounts account2 = ListOfAccounts.Find(r => r._Name == recieveAccount);
            while (account2 == null)
            {
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                recieveAccount = Console.ReadLine();
                account2 = ListOfAccounts.Find(r => r._Name == recieveAccount);
            }
            Console.Write("Skriv hur mycket pengar du vill överföra: ");
            float moneyamount = 0;
            bool isException = false;
            do
            {
                try
                {
                    moneyamount = float.Parse(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                    isException = true;
                }
            }
            while (isException);

            while (moneyamount > account._Balance)
            {
                Console.WriteLine("Det finns för lite pengar på kontot...");
                Console.Write("Skriv in ett nytt belopp: ");
                try
                {
                    moneyamount = float.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                }
            }

            SaveCalculations(moneyamount, (float)ExchangeRate(account, account2, moneyamount), account, account2);
            SaveTransaction(moneyamount, account, false, $"Överföring till annat konto: {account2._Name}");
            SaveTransaction((float)ExchangeRate(account, account2, moneyamount), account2, true, $"Överföring från annat konto: {account._Name}");
            Console.WriteLine("Transaktionerna går egenom om 15 sekunder.");
        }

        public enum Currency
        {
            SEK,
            USD,
            GBP,
            EUR
        }

        public decimal ExchangeRate(Accounts firstAccount, Accounts secondAccount, float moneyAmount)
        {
            decimal result;
            decimal result1 = 0;
            switch (firstAccount._Currency)
            {
                case "SEK":
                    if (secondAccount._Currency == "USD")
                    {
                        result = currencyChange[1] / currencyChange[0];
                        result1 = (decimal)moneyAmount * result;
                    }
                    else if (secondAccount._Currency == "GBP")
                    {
                        result = currencyChange[2] / currencyChange[0];
                        result1 = (decimal)moneyAmount * result;
                    }
                    else if (secondAccount._Currency == "EUR")
                    {
                        result = currencyChange[3] / currencyChange[0];
                        result1 = (decimal)moneyAmount * result;
                    }
                    break;
                case "USD":
                    if (secondAccount._Currency == "SEK")
                    {
                        result = currencyChange[0] / currencyChange[1];
                        result1 = (decimal)moneyAmount * result;
                    }
                    else if (secondAccount._Currency == "GBP")
                    {
                        result = currencyChange[2] / currencyChange[1];
                        result1 = (decimal)moneyAmount / result;
                    }
                    else if (secondAccount._Currency == "EUR")
                    {
                        result = currencyChange[3] / currencyChange[1];
                        result1 = (decimal)moneyAmount / result;
                    }
                    break;
                case "GBP":
                    if (secondAccount._Currency == "SEK")
                    {
                        result = currencyChange[0] / currencyChange[2];
                        result1 = (decimal)moneyAmount * result;
                    }
                    else if (secondAccount._Currency == "USD")
                    {
                        result = currencyChange[1] / currencyChange[2];
                        result1 = (decimal)moneyAmount / result;
                    }
                    else if (secondAccount._Currency == "EUR")
                    {
                        result = currencyChange[3] / currencyChange[2];
                        result1 = (decimal)moneyAmount / result;
                    }
                    break;
                case "EUR":
                    if (secondAccount._Currency == "SEK")
                    {
                        result = currencyChange[0] / currencyChange[3];
                        result1 = (decimal)moneyAmount * result;
                    }
                    else if (secondAccount._Currency == "USD")
                    {
                        result = currencyChange[1] / currencyChange[3];
                        result1 = (decimal)moneyAmount / result;
                    }
                    else if (secondAccount._Currency == "GBP")
                    {
                        result = currencyChange[2] / currencyChange[3];
                        result1 = (decimal)moneyAmount / result;
                    }
                    break;
                default:
                    break;
            }
            if (firstAccount._Currency == secondAccount._Currency)
            {
                return (decimal)moneyAmount;
            }
            else
            {
                return result1;
            }
        }
    }
}
