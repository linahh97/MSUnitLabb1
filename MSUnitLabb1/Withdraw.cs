using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitLabb1
{
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
            BankController.queuedTransactions.Enqueue(savedTransaction); // Bankcontroller
        }

        public List<CreateBankAccount> ListOfAccounts = new List<CreateBankAccount>();

        public int WithdrawMoney(CreateBankAccount withdrawAccount, int money)
        {
            CreateBankAccount a1 = new CreateBankAccount("Spar", 50000, "SEK");
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
