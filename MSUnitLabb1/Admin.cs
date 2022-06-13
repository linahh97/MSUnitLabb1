using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSUnitLabb1
{
    class Admin : Login
    {
        #region Customers & BankAccounts
        Customer U1 = new Customer("Hanna", "0000");
        Customer U2 = new Customer("Daniel", "1111");
        Customer U3 = new Customer("Emma", "2222");

        Accounts a1 = new Accounts("Spar", 50000.00f, "SEK");
        Accounts a2 = new Accounts("Lön", 20000f, "EUR");
        Accounts a3 = new Accounts("Fond", 30000.00f, "SEK");
        Accounts a4 = new Accounts("Aktie", 10000.00f, "SEK");
        Accounts a5 = new Accounts("Privat", 4000.66f, "SEK");
        Accounts a6 = new Accounts("Investeringar", 99999.02f, "SEK");
        #endregion

        public List<Customer> ListOfCustomers = new List<Customer>();

        public void AdminSetup()
        {
            U1.AddAccounts(a1); U1.AddAccounts(a2);  //First user's accounts
            U2.AddAccounts(a3); U2.AddAccounts(a4);  //Second user's account
            U3.AddAccounts(a5); U3.AddAccounts(a6);
            ListOfCustomers.Add(U1);
            ListOfCustomers.Add(U2);
            ListOfCustomers.Add(U3);
        }

        public void ShowCustomers()
        {
            foreach (var customer in ListOfCustomers)
            {
                Console.WriteLine("Användare: " + customer.UserName + ", Antal konton: " + customer.ListOfAccounts.Count);
            }
        }
    }
}
