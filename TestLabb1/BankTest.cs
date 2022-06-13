using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSUnitLabb1;

namespace TestLabb1
{
    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void Change_Password()
        {
            //Arrange
            string password = "lolo1234";

            //Act
            bool isValid = Password.ChangePassword(password);

            //Assert
            Assert.IsTrue(isValid, $"The password {password} is not valid");
        }

        [TestMethod]
        public void Create_Savings_Account()
        {
            //Arrange
            CreateBankAccount a1 = new CreateBankAccount("Spar", 50000, "SEK");
            CreateBankAccount a2 = new CreateBankAccount("Lön", 20000, "EUR");
            CreateBankAccount a3 = new CreateBankAccount("Fond", 30000, "SEK");

            CreateAccount t = new CreateAccount();

            string name = "Spar";
            int acc = 300;
            string cur = "USD";

            //Act
            string actual = t.CreateSavingsAccount(name, acc, cur);
            string expected = "valid";

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Withdraw_Money_From_Account()
        {
            //Arrange
            CreateBankAccount a1 = new CreateBankAccount("Spar", 50000, "SEK");
            
            Withdraw w = new Withdraw();

            //Act
            var actual = w.WithdrawMoney(a1, 51000);

            //Assert
            Assert.AreEqual(-1000, actual);
        }
    }
}