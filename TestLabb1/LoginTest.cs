using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSUnitLabb1;

namespace TestLabb1
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void Change_Password()
        {
            //Arrange
            string password = "lolo1234";

            //Act
            bool isValid = BankClass.ChangePassword(password);

            //Assert
            Assert.IsTrue(isValid, $"The password {password} is not valid");
        }

        [TestMethod]
        public void Create_Savings_Account()
        {
            //Arrange
            BankClass a1 = new BankClass("Spar", 50000, "SEK");
            BankClass a2 = new BankClass("Lön", 20000, "EUR");
            BankClass a3 = new BankClass("Fond", 30000, "SEK");

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
            BankClass a1 = new BankClass("Spar", 50000, "SEK");
            
            Withdraw w = new Withdraw();

            //Act
            var actual = w.WithdrawMoney(a1, 51000);

            //Assert
            Assert.AreEqual(-1000, actual);
        }
    }
}